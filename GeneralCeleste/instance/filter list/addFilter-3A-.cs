addFilter: filter 
	"add the specified filter"

	self activeFilters addLast: filter.
	selectedActiveFilterIndex := self activeFilters size.
	self filtersChanged