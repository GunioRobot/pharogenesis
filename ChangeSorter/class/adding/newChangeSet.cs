newChangeSet
	"Prompt the user for a name, and establish a new change set of
	that name (if ok), making it the current changeset.  Return nil
	of not ok, else return the actual changeset."

	| newName newSet |
	newName _ FillInTheBlank
		request: 'Please name the new change set:'
		initialAnswer: ChangeSet defaultName.
	newName isEmptyOrNil ifTrue:
		[^ nil].
	newSet _ self basicNewChangeSet: newName.
	newSet ifNotNil:
		[ChangeSet  newChanges: newSet].
	^ newSet