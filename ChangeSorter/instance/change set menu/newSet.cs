newSet
	"Create a new changeSet and show it.  For splitting an existing one that is showing in the other pane..  1991-tck.
	 3/9/96 sw: make the new guy the current one, corresponding to 99.5% of normal use.  Also, reject name if already in use."

	| newName newSet |
	newName _ FillInTheBlank request: 'A name for the new change set'
			initialAnswer: ChangeSet defaultName.

	newName isEmpty ifTrue: [^ self].
	(self class changeSetNamed: newName) ~~ nil
		ifTrue:
			[self inform: 'Sorry that name is already used'.
			^ self].

	newSet _ ChangeSet new initialize name: newName.
	AllChangeSets add: newSet.
	self showChangeSet: newSet.
	self newCurrent.
