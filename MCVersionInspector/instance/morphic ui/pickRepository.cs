pickRepository
	| index |
	index := (PopUpMenu labelArray: (self repositories collect: [:ea | ea description]))
				startUpWithCaption: 'Repository:'.
	^ index = 0 ifFalse: [self repositories at: index]