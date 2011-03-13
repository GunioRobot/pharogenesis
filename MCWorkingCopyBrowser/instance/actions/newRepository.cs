newRepository
	| types index |
	types := MCRepository allConcreteSubclasses asArray.
	index := (PopUpMenu labelArray: (types collect: [:ea | ea description]))
				startUpWithCaption: 'Repository type:'.
	^ index = 0 ifFalse: [(types at: index) morphicConfigure]