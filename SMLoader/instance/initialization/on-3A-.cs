on: aSqueakMap 
	"Initialize instance."

	model := aSqueakMap.
	model synchWithDisk.
	filters := DefaultFilters copy.
	categoriesToFilterIds := DefaultCategoriesToFilterIds copy.
	self askToLoadUpdates