mouseDown: evt

	| state |
	(drawState includesKey: evt hand) ifFalse: [self createDrawStateFor: evt hand].
	state _ drawState at: evt hand.
	state at: LastMouseIndex put: evt cursorPoint.
