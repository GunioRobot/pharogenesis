restoreMorphicForeground: aRectangle above: aMorph
	"If necessary upload the contents of aRectangle from the rendering target into the engine."
	| backingTexture x0 y0 x1 y1 y x backingBox box texRect morphList fixBlt |
	morphList _ WriteStream on: #().
	aMorph morphsInFrontOverlapping: aRectangle do:[:m| morphList nextPut: m].
	morphList _ morphList contents.
	morphList isEmpty ifTrue:[^self].
	target ifNotNil:[
		"As usual, it's a lot faster and easier if we have framebuffer access"
		self finish. "need to finish 3D rendering"
		target getCanvas translateBy: aRectangle origin negated during:[:canvas|
			morphList reverseDo:[:m|
				canvas transformBy: m transformFromWorld inverseTransformation
						clippingTo: aRectangle
						during:[:c| c fullDrawMorph: m]]].
		^self].

	"Compute the backing box; e.g., the area that needs compositing"
	backingBox _ nil.
	morphList reverseDo:[:m|
		box _ m fullBoundsInWorld intersect: aRectangle.
		box area > 0 ifTrue:[
			backingBox == nil 
				ifTrue:[backingBox _ box]
				ifFalse:[backingBox _ backingBox quickMerge: box]]].
	backingBox == nil ifTrue:[^self].


	backingTexture _ self allocateOrRecycleTexture: backingForm.
	"@@@: Hack. Silently back out if the backing texture is nil.
	Has been noted by Alan and I *think* this is just a problem
	for a frame or so.
	If whoever reads this thinks it's a decidedly bad idea to just
	back out, then go ahead and remove that test. But try to test
	for a nil return value first - this should be more than a hint
	that something went wrong here."
	backingTexture ifNil:[^nil].

	x0 _ backingBox left truncated.
	y0 _ backingBox top truncated.
	x1 _ backingBox right truncated.
	y1 _ backingBox bottom truncated.

	fixBlt := BitBlt toForm: backingForm.
	fixBlt combinationRule: 40 "fixAlpha:with:".
	fixBlt fillColor: (Bitmap with: 16rFF000000).

	y _ y0.
	[y < y1] whileTrue:[
		x _ x0.
		[x < x1] whileTrue:[
			"Clean up texture - in many cases we might not have to draw anything"
			backingForm hasBeenModified: false.
			"The current drawing rectangle"
			texRect _ x@y extent: backingForm extent.
			"Draw the current patch"
			backingForm getCanvas translateBy: (x@y) negated during:[:canvas|
				morphList reverseDo:[:m|
					canvas transformBy: m transformFromWorld inverseTransformation
							clippingTo: texRect
							during:[:c| c fullDrawMorph: m]]].
			backingForm hasBeenModified ifTrue:[
				"@@@ FIXME: Fix #displayOn: to use real color map if needed"
				fixBlt copyBits.
				self displayForm: backingForm on: backingTexture.
				self uploadTexture: backingTexture.
				self compositeTexture: backingTexture at: x@y translucent: true.
			].
			x _ x + backingTexture width.
		].
		y _ y + backingTexture height.
	].
