initialize
	| |
	super initialize.
	borderWidth _ 2.  borderColor _ #inset.

	yScrollBar := ScrollBar new model: self slotName: 'yScrollBar'.
	yScrollBar borderWidth: 2; borderColor: #inset.
	self addMorph: yScrollBar.

	xScrollBar := ScrollBar new model: self slotName: 'xScrollBar'.
	xScrollBar borderWidth: 2; borderColor: #inset.
	self addMorph: xScrollBar.

	scroller := TransformMorph new color: Color transparent.
	scroller offset: 0@0.
	self addMorph: scroller.

	self on: #mouseEnter send: #mouseEnter: to: self.
	self on: #mouseLeave send: #mouseLeave: to: self.
	self extent: 150@120