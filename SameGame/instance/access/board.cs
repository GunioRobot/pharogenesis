board

	board ifNil:
		[board _ SameGameBoard new
			target: self;
			actionSelector: #selection].
	^ board