newList
	"Make the list be those file names which match the pattern."
	Cursor execute showWhile:
		[list _ (pattern includes: $*) | (pattern includes: $#)
			ifTrue: [self listForPattern: pattern]
			ifFalse: [pattern isEmpty
					ifTrue: [self listForPattern: '*']
					ifFalse: [self listForPattern: '*', pattern, '*']].
		listIndex _ 0.
		volListIndex _ volList size.
		contents _ ''.
		self changed: #listIndex.
		self changed: #fileList]
