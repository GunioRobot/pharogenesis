scrollBarFills: aRectangle
	"Return true if a flop-out scrollbar fills the rectangle"
	^ (retractableScrollBar and: [submorphs includes: scrollBar]) and:
		[scrollBar bounds containsRect: aRectangle]