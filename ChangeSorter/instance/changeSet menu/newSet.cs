newSet
	"Create a new changeSet and show it.  make the new guy the current one.  Also, reject name if already in use."
	| newName newSet |

	self okToChange ifFalse: [^ self].
	newName _ FillInTheBlank request: 'A name for the new change set'
			initialAnswer: ChangeSet defaultName.
	newName isEmpty ifTrue: [^ self].
	(self class changeSetNamed: newName) ifNotNil:
			[^ self inform: 'Sorry that name is already used'].

	newSet _ ChangeSet new initialize name: newName.
	AllChangeSets add: newSet.
	self showChangeSet: newSet.
	self newCurrent.
