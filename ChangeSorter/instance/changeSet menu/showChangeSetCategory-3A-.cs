showChangeSetCategory: aChangeSetCategory
	"Show the given change-set category"
	
	changeSetCategory := aChangeSetCategory.
	self changed: #changeSetList.
	(self changeSetList includes: myChangeSet name) ifFalse:
			[self showChangeSet: (ChangesOrganizer changeSetNamed: self changeSetList first)].
	self changed: #relabel