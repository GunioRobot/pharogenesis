setPenColor: evt
	| state |
	(drawState includesKey: evt hand) ifFalse: [self createDrawStateFor: evt hand].
	state _ drawState at: evt hand.
	evt hand changeColorTarget: self selector: #brushColor:hand: originalColor: (state at: PenColorIndex).
