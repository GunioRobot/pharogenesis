addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	running
		ifTrue: [aCustomMenu add: 'stop' action: #stopRunning]
		ifFalse: [aCustomMenu add: 'start' action: #startRunning].
