rename
	"Store a new name string into the selected ChangeSet.  1991-tck.
	 3/9/96 sw: several fixes:  reject duplicate name; allow user to back out"

	| newName |
	newName _ FillInTheBlank request: 'A name for this change set'
						initialAnswer: myChangeSet name.
	(newName = myChangeSet name or:
		[newName size == 0]) ifTrue:
			[^ self inform: 'No change made'].

	(self class changeSetNamed: newName) ~~ nil
		ifTrue:
			[Utilities inform: 'Sorry that name is already used'.
			^ self].

	myChangeSet name: newName.
	buttonView label: newName asParagraph.
	buttonView display.
	myChangeSet == Smalltalk changes ifTrue:
		[buttonView topView relabel: self label]