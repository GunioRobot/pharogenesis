fieldOffset  "Return temp or instVar offset for this variable"

	code < 256
		ifTrue: 
			[^ code \\ 16]
		ifFalse: 
			[^ code \\ 256]