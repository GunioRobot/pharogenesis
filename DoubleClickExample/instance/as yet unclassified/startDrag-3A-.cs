startDrag: evt
	"We'll get a mouseDown first, some mouseMoves, and a mouseUp event last"
	| oldCenter |
	evt isMouseDown ifTrue:
		[self showBalloon: 'drag (mouse down)' hand: evt hand.
		self world displayWorld.
		(Delay forMilliseconds: 750) wait].
	evt isMouseUp ifTrue:
		[self showBalloon: 'drag (mouse up)' hand: evt hand].
	(evt isMouseUp or: [evt isMouseDown]) ifFalse:
		[self showBalloon: 'drag (mouse still down)' hand: evt hand].
	(self containsPoint: evt cursorPoint)
		ifFalse: [^ self].

	oldCenter _ self center.
	color = Color red
		ifTrue:
			[self extent: self extent + (1@1)]
		ifFalse:
			[self extent: ((self extent - (1@1)) max: (16@16))].
	self center: oldCenter