summariesForUpdates: startNumber through: stopNumber
	"Answer the concatenation of summary strings for updates numbered in the given range"

	^ String streamContents: [:aStream |
		((ChangeSorter changeSetsNamedSuchThat:
			[:aName | aName first isDigit and:
						[aName initialIntegerOrNil >= startNumber] and:
						[aName initialIntegerOrNil <= stopNumber]]) asSortedCollection:
				[:a :b | a name < b name]) do:
					[:aChangeSet | aStream cr; nextPutAll: aChangeSet summaryString]]

"Utilities summariesForUpdates: 4899 through: 4903"

