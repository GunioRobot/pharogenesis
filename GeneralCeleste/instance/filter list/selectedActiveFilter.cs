selectedActiveFilter
	"return the filter that is currently selected, or nil if none is selected"

	selectedActiveFilterIndex = 0 ifTrue: [^nil].
	^self activeFilters at: self selectedActiveFilterIndex