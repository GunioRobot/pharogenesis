newChangeSet
	"Prompt the user for a name, and establish a new change set of that name (if ok), making it the current changeset.  Return nil of not ok, else return the actual changeset."

	| newName newSet |
	newName _ FillInTheBlank request: 'Please name the new change set:'
			initialAnswer: ChangeSet defaultName.
	newName isEmpty ifTrue:
		[self inform: 'nothing done'.
		^ nil].
	(self changeSetNamed: newName) ifNotNil:
			[self inform: 'Sorry that name is already used'.
			^ nil].

	newSet _ ChangeSet new initialize name: newName.
	AllChangeSets add: newSet.
	Smalltalk newChanges: newSet.
	Transcript cr; show: newName, ' is now the current change set'.
	^ newSet
