absorbChangesInChangeSetsNamed: nameList
	"Absorb into the receiver all the changes found in  change sets of the given names.  *** classes renamed in aChangeSet may have have problems
1/22/96 sw"

	| aChangeSet |
	nameList do:
		[:aName | (aChangeSet _ ChangeSorter changeSetNamed: aName) ~~ nil
			ifTrue:
				[self assimilateAllChangesFoundIn: aChangeSet]]