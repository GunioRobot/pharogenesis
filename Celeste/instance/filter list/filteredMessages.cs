filteredMessages
	"return a list of message ID's that match the current filters"

	| unsorted |
	self activeFilters isEmpty 
		ifTrue: 
			["no filters is somewhat frequent and can easily be expensive!  Use the pre-sorted list of messages"

			^mailDB allMessagesSorted].
	unsorted := self activeFilters allButFirst 
				inject: (self activeFilters first allMatchingIDsIn: mailDB)
				into: [:matchingIDs :filter | filter allMatchingIDsAmong: matchingIDs in: mailDB].
	^mailDB sortedKeysForMessages: unsorted