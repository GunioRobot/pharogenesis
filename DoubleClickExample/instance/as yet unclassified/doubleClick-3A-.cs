doubleClick: evt
	self showBalloon: 'doubleClick'.
	self color: ((color = Color blue) ifTrue: [Color red] ifFalse: [Color blue])
