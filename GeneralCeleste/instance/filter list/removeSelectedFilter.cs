removeSelectedFilter
	"check that a filter is actually selected"

	selectedActiveFilterIndex = 0 ifTrue: [^self].

	"remove the filter"
	self activeFilters removeAt: selectedActiveFilterIndex.

	"update the index.  In the normal case point to the same index; in any case, don't point past the end of the list of filters.  If the list has become empty, then note that the index goes to 0, as it should"
	selectedActiveFilterIndex := selectedActiveFilterIndex 
				min: self activeFilters size.
	self filtersChanged