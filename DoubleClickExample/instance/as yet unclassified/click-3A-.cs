click: evt
	self showBalloon: 'click' hand: evt hand.
	self borderColor: (self borderColor = Color black ifTrue: [Color yellow] ifFalse: [Color black])
