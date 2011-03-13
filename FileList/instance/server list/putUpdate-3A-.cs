putUpdate: fullFileName
	"Put this file out as an Update on the servers."

	| names choice |
	self canDiscardEdits ifFalse: [^ self changed: #flash].
	names := ServerDirectory groupNames asSortedArray.
	choice := UIManager default chooseFrom: names values: names.
	choice ifNil: [^ self].
	(ServerDirectory serverInGroupNamed: choice) putUpdate: 
				(directory oldFileNamed: fullFileName).
	self volumeListIndex: volListIndex.
