pickRepositorySatisfying: aBlock
	| index list |
	list := MCRepositoryGroup default repositories select: aBlock.
	index := (PopUpMenu labelArray: (list collect: [:ea | ea description]))
		startUpWithCaption: 'Repository:'.
	^ index = 0 ifFalse: [list at: index]