putUpdate
	"Put this file out as an Update on the servers."
	| names choice |
	self canDiscardEdits ifFalse: [^ self changed: #flash].

	names _ ServerDirectory groupNames asSortedArray.
	choice _ (SelectionMenu labelList: names selections: names) startUp.
	choice == nil ifTrue: [^ self].
	(ServerDirectory groupNamed: choice) putUpdate: 
				(directory oldFileNamed: self fullName).
	self volumeListIndex: volListIndex.
