restoreMorphicBackground: aRectangle under: aMorph
	"If necessary upload the contents of aRectangle from the rendering target into the engine."
	| backingTexture x0 y0 x1 y1 y x |
	target ifNotNil:["It's a lot simpler and faster to do it this way"
		^self displayForm: Display on: target from: aRectangle origin.
	].
	backingTexture _ self allocateOrRecycleTexture: backingForm.

	x0 _ aRectangle left truncated.
	y0 _ aRectangle top truncated.
	x1 _ aRectangle right truncated.
	y1 _ aRectangle bottom truncated.

	y _ y0.
	[y < y1] whileTrue:[
		x _ x0.
		[x < x1] whileTrue:[
			Display displayOn: backingForm at: (x@y) negated.
			"@@@ FIXME: Fix #displayOn: to use real color map if needed"
			self displayForm: backingForm on: backingTexture.
			self uploadTexture: backingTexture.
			self compositeTexture: backingTexture at: x@y translucent: false.
			x _ x + backingTexture width.
		].
		y _ y + backingTexture height.
	].