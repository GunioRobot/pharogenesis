scroller: aTransformMorph
	scroller ifNotNil:[scroller delete].
	scroller _ aTransformMorph.
	self addMorph: scroller.
	self resizeScroller.