using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PandaScore.NET.LoL
{
    [Flags]
    internal enum QueryOptionType
    {
        None = 0,
        Filter = 1,
        Search = 2,
        Range = 4,
        Sort = 8,
        FilterAndRange = Filter | Range,
        FilterRangeSort = Filter | Sort | Range,
        All = Filter | Range | Sort | Search,
        FilterSearchSort = Filter | Search | Sort,
    }

    public abstract class QueryOption
    {
        internal abstract string ToFilterString();
        internal abstract string ToSearchString();
        internal abstract string ToRangeString();
        internal abstract string ToSortString();
        internal QueryOptionType CurrentType { get; set; }

        internal event Action<QueryOption, bool> SortChanged;

        protected void OnSortChanged(QueryOption obj, bool added)
        {
            SortChanged?.Invoke(obj, added);
        }
    }

    public class QueryOption<T> : QueryOption
    {

        QueryOptionType acceptedType;
        T filterValue;
        T min;
        T max;
        string searchValue;
        string optionName;
        string sortString;
        static NumberFormatInfo numberFormat;

        static QueryOption()
        {
            numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalSeparator = ".";
        }

        internal QueryOption(string optionName, QueryOptionType type)
        {
            this.acceptedType = type;
            this.optionName = optionName;
        }

        /// <summary>
        /// Sets the query to return items that match this value exactly.
        /// </summary>
        /// <param name="value">Value of the filter.</param>
        /// <exception cref="ArgumentException">Thrown when the property cannot be used to filter results or when the supplied value is null.</exception>
        public void Filter(T value)
        {
            if ((acceptedType & QueryOptionType.Filter) != QueryOptionType.Filter)
            {
                throw new ArgumentException("This property cannot be used to filter results!");
            }
            if (value == null)
            {
                throw new ArgumentException("Value cannot be null! Use the UnsetFilter method instead.");
            }
            this.filterValue = value;
            CurrentType |= QueryOptionType.Filter;
        }

        /// <summary>
        /// Sets the query to return items that fall within this range. 
        /// </summary>
        /// <param name="min">Lower bound of the range.</param>
        /// <param name="max">Upper bound of the range.</param>
        /// <exception cref="ArgumentException">Thrown when the property cannot be used to filter results or when one or both of the supplied values is null.</exception>
        public void Range(T min, T max)
        {
            if ((acceptedType & QueryOptionType.Range) != QueryOptionType.Range)
            {
                throw new ArgumentException("This property cannot be used to set a result range!");
            }
            if (min == null || max == null)
            {
                throw new ArgumentException("Value cannot be null! Use the UnsetRange method instead.");
            }
            this.min = min;
            this.max = max;
            CurrentType |= QueryOptionType.Range;
        }

        /// <summary>
        /// Sorts results by this property in ascending order. The ordering of sort options is important!
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the property cannot be used to sort results.</exception>
        public void Sort()
        {
            if ((acceptedType & QueryOptionType.Sort) != QueryOptionType.Sort)
            {
                throw new ArgumentException("This property cannot be used to sort results!");
            }
            this.sortString = optionName;
            CurrentType |= QueryOptionType.Sort;
            OnSortChanged(this, true);
        }

        /// <summary>
        /// Sorts results by this property in descending order. The ordering of sort options is important!
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the property cannot be used to sort results.</exception>
        public void SortDescending()
        {
            if ((acceptedType & QueryOptionType.Sort) != QueryOptionType.Sort)
            {
                throw new ArgumentException("This property cannot be used to sort results!");
            }
            this.sortString = "-" + optionName;
            CurrentType |= QueryOptionType.Sort;
            OnSortChanged(this, true);
        }

        /// <summary>
        /// Sets the query to search items that contain this value. Can only be used with string values.
        /// </summary>
        /// <param name="value">Search term.</param>
        /// <exception cref="ArgumentException">Thrown when the property cannot be used to filter results or when the supplied value is null.</exception>
        public void Search(string value)
        {
            //filterable also means searchable
            if ((acceptedType & QueryOptionType.Filter) != QueryOptionType.Filter)
            {
                throw new ArgumentException("This property cannot be used to search results!");
            }
            if (value == null)
            {
                throw new ArgumentException("Value cannot be null! Use the UnsetSearch method instead.");
            }
            this.searchValue = value;
            CurrentType |= QueryOptionType.Search;
        }

        /// <summary>
        /// Removes any filters applied to this property.
        /// </summary>
        public void UnsetFilter()
        {
            CurrentType &= ~QueryOptionType.Filter;
        }

        /// <summary>
        /// Removes any search terms applied to this property.
        /// </summary>
        public void UnsetSearch()
        {
            CurrentType &= ~QueryOptionType.Search;
        }

        /// <summary>
        /// Removes any range values applied to this property.
        /// </summary>
        public void UnsetRange()
        {
            CurrentType &= ~QueryOptionType.Range;
        }

        /// <summary>
        /// Removes any sorting options applied to this property.
        /// </summary>
        public void UnsetSort()
        {
            CurrentType &= ~QueryOptionType.Sort;
            OnSortChanged(this, false);
        }
        
        internal override string ToFilterString()
        {
            if (filterValue is IFormattable f)
            {
                return $"filter[{optionName}]={f.ToString("", numberFormat)}";
            }
            else
            {
                return $"filter[{optionName}]={filterValue}";
            }
        }

        internal override string ToRangeString()
        {
            if (min is IFormattable minValue)
            {
                IFormattable maxValue = max as IFormattable;
                return $"range[{optionName}]={minValue.ToString("", numberFormat)},{maxValue.ToString("", numberFormat)}";
            }
            else
            {
                return $"range[{optionName}]={min},{max}";
            }
        }

        internal override string ToSortString()
        {
            return sortString;
        }

        internal override string ToSearchString()
        {
            return $"search[{optionName}]={searchValue}";
        }
    }
}
