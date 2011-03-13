nextPutImage: aForm

	| f newF |
	aForm unhibernate.
	f _ aForm colorReduced.  "minimize depth"
	f depth > 8 ifTrue: [
		self error: 'GIF cannot store images with over 256 colors'].
	f depth < 8 ifTrue: [
		"writeBitData: expects depth of 8"
		newF _ f class extent: f extent depth: 8.
		(f isKindOf: ColorForm)
			ifTrue: [
				newF
					copyBits: f boundingBox
					from: f at: 0@0
					clippingBox: f boundingBox
					rule: Form over
					fillColor: nil
					map: nil.
				newF colors: f colors]
			ifFalse: [f displayOn: newF].
		f _ newF].
	(f isKindOf: ColorForm)
		ifTrue: [
			(f colorsUsed includes: Color transparent) ifTrue: [
				transparentIndex _ (f colors indexOf: Color transparent) - 1]]
		ifFalse: [transparentIndex _ nil].
	width _ f width.
	height _ f height.
	bitsPerPixel _ f depth.
	colorPalette _ f colormapIfNeededForDepth: 32.
	interlace _ false.
	self writeHeader.
	self writeBitData: f bits.
	self close.
