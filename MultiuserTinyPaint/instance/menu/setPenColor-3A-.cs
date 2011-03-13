setPenColor: evt
	| state |
	(drawState includesKey: evt hand) ifFalse: [self createDrawStateFor: evt hand].
	state _ drawState at: evt hand.
	self changeColorTarget: self selector: #brushColor:hand: originalColor: (state at: PenColorIndex) hand: evt hand