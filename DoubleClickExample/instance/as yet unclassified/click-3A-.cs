click: evt
	self showBalloon: 'click'.
	self borderColor: (self borderColor = Color black ifTrue: [Color yellow] ifFalse: [Color black])
