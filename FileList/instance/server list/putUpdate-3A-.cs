putUpdate: fullFileName
	"Put this file out as an Update on the servers."

	| names choice |
	self canDiscardEdits ifFalse: [^ self changed: #flash].
	names _ ServerDirectory groupNames asSortedArray.
	choice _ (SelectionMenu labelList: names selections: names) startUp.
	choice == nil ifTrue: [^ self].
	(ServerDirectory serverInGroupNamed: choice) putUpdate: 
				(directory oldFileNamed: fullFileName).
	self volumeListIndex: volListIndex.
