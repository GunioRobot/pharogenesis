editSelectedFilter
	"check that a filter is actually selected"
	selectedActiveFilterIndex = 0 ifTrue:[ ^self ].

	"edit the filter"
	self selectedActiveFilter editForMailDB: mailDB.


	self filtersChanged
