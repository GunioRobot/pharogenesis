brushColor: aColor hand: hand

	| state |
	(drawState includesKey: hand) ifFalse: [self createDrawStateFor: hand].
	state _ drawState at: hand.
	(state at: PenIndex) color: aColor.
	state at: PenColorIndex put: aColor.
