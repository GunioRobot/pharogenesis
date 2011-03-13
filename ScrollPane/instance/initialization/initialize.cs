initialize
	| |
	super initialize.
	borderWidth _ 2.  borderColor _ #inset.
	retractableScrollBar _ scrollBarOnLeft _ true.

	scrollBar := ScrollBar new model: self slotName: 'scrollBar'.
	scrollBar borderWidth: 2; borderColor: #inset.
	retractableScrollBar ifFalse: [self addMorph: scrollBar].

	scroller := TransformMorph new color: Color transparent.
	scroller offset: -3@0.
	self addMorph: scroller.

	self on: #mouseEnter send: #mouseEnter: to: self.
	self on: #mouseLeave send: #mouseLeave: to: self.
	self extent: 150@120