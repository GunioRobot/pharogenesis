resizeScroller
	| d inner |
	d _ retractableScrollBar ifTrue: [16@0] ifFalse: [0@0].
	inner _ self innerBounds.
	scroller bounds: (scrollBarOnLeft
		ifTrue: [inner topLeft + (16@0) - d corner: inner bottomRight]
		ifFalse: [inner topLeft corner: inner bottomRight - (16@0) + d])