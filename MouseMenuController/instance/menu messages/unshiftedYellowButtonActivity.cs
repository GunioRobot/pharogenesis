unshiftedYellowButtonActivity
	"Put up the regular yellow-button menu and take action as appropriate"

	| index  |
	yellowButtonMenu ~~ nil
		ifTrue: 
			[index _ self startUpYellowButtonMenu.
			index ~= 0 
				ifTrue: [self menuMessageReceiver performMenuMessage:
							(yellowButtonMessages at: index)]]
		ifFalse:
			[super controlActivity]