initialize
	super initialize.
	hasFocus _ false.
	borderWidth _ 2.
	borderColor _ Color black.
	retractableScrollBar _ (Preferences valueOfFlag: #inboardScrollbars) not.
	scrollBarOnLeft _ (Preferences valueOfFlag: #scrollBarsOnRight) not.

	scrollBar := ScrollBar new model: self slotName: 'scrollBar'.
	scrollBar borderWidth: 1; borderColor: Color black.

	scroller := TransformMorph new color: Color transparent.
	scroller offset: -3@0.
	self addMorph: scroller.

	retractableScrollBar ifFalse: [self addMorph: scrollBar].

	self on: #mouseEnter send: #mouseEnter: to: self.
	self on: #mouseLeave send: #mouseLeave: to: self.
	self extent: 150@120