initializeScrollBars
"initialize the receiver's scrollBar"

	(scrollBar := ScrollBar new model: self slotName: 'vScrollBar')
			borderWidth: 1; 
			borderColor: Color black.
	(hScrollBar := ScrollBar new model: self slotName: 'hScrollBar')
			borderWidth: 1; 
			borderColor: Color black.

	""
	scroller := TransformMorph new color: Color transparent.
	scroller offset: -3 @ 0.
	self addMorph: scroller.
	""
	scrollBar initializeEmbedded: retractableScrollBar not.
	hScrollBar initializeEmbedded: retractableScrollBar not.
	retractableScrollBar ifFalse: 
			[self 
				addMorph: scrollBar;
				addMorph: hScrollBar].

	Preferences alwaysShowVScrollbar ifTrue:
		[ self alwaysShowVScrollBar: true ].
		
	Preferences alwaysHideHScrollbar
		ifTrue:[self hideHScrollBarIndefinitely: true ]
		ifFalse:
			[Preferences alwaysShowHScrollbar ifTrue:
				[ self alwaysShowHScrollBar: true ]].
