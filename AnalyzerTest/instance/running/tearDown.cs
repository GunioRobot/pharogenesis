tearDown

	| name |
	classesCreated
		do: [:cls | 
			name _ cls name.
			self removeClassNamedIfExists: name.
			ChangeSet current removeClassChanges: name].
	classesCreated _ nil