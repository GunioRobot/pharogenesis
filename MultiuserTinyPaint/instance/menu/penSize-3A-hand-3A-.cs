penSize: anInteger hand: hand

	| state |
	(drawState includesKey: hand) ifFalse: [self createDrawStateFor: hand].
	state _ drawState at: hand.
	state at: PenSizeIndex put: anInteger.
	(state at: PenIndex) roundNib: anInteger.
