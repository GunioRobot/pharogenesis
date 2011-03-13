rename
	"Store a new name string into the selected ChangeSet.  reject duplicate name; allow user to back out"

	| newName |
	newName _ FillInTheBlank request: 'New name for this change set'
						initialAnswer: myChangeSet name.
	(newName = myChangeSet name or: [newName size == 0]) ifTrue:
			[^ self inform: 'No change made'].

	(self class changeSetNamed: newName) ifNotNil:
			[^ Utilities inform: 'Sorry that name is already used'].

	myChangeSet name: newName.
	self changed: #mainButtonName.
	self changed: #relabel.