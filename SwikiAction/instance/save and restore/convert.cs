convert
	"Make all my pages obey the new format -- all versions in one file, file name is just a single number."

	| old new nn |
	urlmap pages do: [:page |
		old _ page file.   nn _ old size.
		(old at: nn) isDigit & ((old at: nn-1) == $.)
			ifFalse: [self error: 'May not be an old style page']
			ifTrue: [new _ old copyFrom: 1 to: nn-2.	"knock off .4"
				page file: new.
				page text: (FileStream readOnlyFileNamed: old) contentsOfEntireFile]].
	