openOnDatabase: aMailDB 
	self activeFilters: OrderedCollection new.
	selectedActiveFilterIndex := 0.
	super openOnDatabase: aMailDB