on: aSqueakMap 
	"Initialize instance."

	squeakMap := aSqueakMap.
	squeakMap synchWithDisk.
	filters := DefaultFilters copy.
	categoriesToFilterIds := DefaultCategoriesToFilterIds copy.
	self askToLoadUpdates