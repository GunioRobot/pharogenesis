board

	board ifNil: 
		[board _ FreeCellBoard new
			target: self;
			actionSelector: #boardAction:].
	^board