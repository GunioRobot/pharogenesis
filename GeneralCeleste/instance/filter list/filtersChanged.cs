filtersChanged 
	super filtersChanged.
	self changed: #activeFilterDescriptions.
	self changed: #selectedActiveFilterIndex.