showCover
	"Remove the current EToy and show the front cover"

	frontCover ifNil: [self createFrontCover].
	self removeAllMorphs.
	presenter _ nil.
	self adjustTabs. 
	self addMorph: frontCover.
	viewBox ifNotNil:
		[Display wipeImage: self imageForm at: viewBox origin delta: 1@0 clippingBox: viewBox].
