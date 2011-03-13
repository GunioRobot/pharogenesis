unshiftedYellowButtonActivity
	"Put up the regular yellow-button menu and take action as appropriate.  1/24/96 sw"

	| index  |

	yellowButtonMenu ~~ nil
		ifTrue: 
			[index _ yellowButtonMenu startUpYellowButton.
			index ~= 0 
				ifTrue: [self menuMessageReceiver performMenuMessage:
							(yellowButtonMessages at: index)]]
		ifFalse:
			[super controlActivity]