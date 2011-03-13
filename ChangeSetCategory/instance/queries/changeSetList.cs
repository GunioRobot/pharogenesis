changeSetList
	"Answer the list of change-set names in the category"

	| aChangeSet |
	self reconstituteList.
	keysInOrder size == 0 ifTrue:
		["don't tolerate emptiness, because ChangeSorters gag when they have no change-set selected"
		aChangeSet := ChangeSorter assuredChangeSetNamed: 'New Changes'.
		self elementAt: aChangeSet name put: aChangeSet].
	^ keysInOrder reversed