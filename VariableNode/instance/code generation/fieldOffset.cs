fieldOffset  "Return temp or instVar offset for this variable"

	self code < 256
		ifTrue: 
			[^ self code \\ 16]
		ifFalse: 
			[^ self code \\ 256]