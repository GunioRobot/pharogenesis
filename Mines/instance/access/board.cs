board

	board ifNil:
		[board _ MinesBoard new
			target: self;
			actionSelector: #selection].
	^ board