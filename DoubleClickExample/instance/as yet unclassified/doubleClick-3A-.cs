doubleClick: evt
	self showBalloon: 'doubleClick' hand: evt hand.
	self color: ((color = Color blue) ifTrue: [Color red] ifFalse: [Color blue])
