readNextUpdatesFromDisk: n
	"Read the updates up through the current highest-update-number plus n.  Thus, 
	Utilities readNextUpdatesFromDisk: 7
will read the next seven updates from disk"

	self applyUpdatesFromDiskToUpdateNumber: ChangeSorter highestNumberedChangeSet + n
		stopIfGap: false