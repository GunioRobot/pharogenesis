fillBitmapSpanAA: bmFill from: leftX to: rightX at: yValue
	| x dsX ds dtX dt deltaX deltaY bits xp yp bmWidth bmHeight fillValue baseShift cMask cShift idx aaLevel firstPixel lastPixel tileFlag |
	self inline: false.
	self var: #bits declareC:'int *bits'.
	bits _ self loadBitsFrom: bmFill.
	bits == nil ifTrue:[^nil].
	bmWidth _ self bitmapWidthOf: bmFill.
	bmHeight _ self bitmapHeightOf: bmFill.
	tileFlag _ (self bitmapTileFlagOf: bmFill) = 1.
	deltaX _ leftX - (self fillOriginXOf: bmFill).
	deltaY _ yValue - (self fillOriginYOf: bmFill).
	dsX _ self fillDirectionXOf: bmFill.
	dtX _ self fillNormalXOf: bmFill.

	ds _ (deltaX * dsX) + (deltaY * (self fillDirectionYOf: bmFill)).
	dt _ (deltaX * dtX) + (deltaY * (self fillNormalYOf: bmFill)).

	aaLevel _ self aaLevelGet.
	firstPixel _ self aaFirstPixelFrom: leftX to: rightX.
	lastPixel _ self aaLastPixelFrom: leftX to: rightX.
	baseShift _ self aaShiftGet.
	cMask _ self aaColorMaskGet.
	cShift _ self aaColorShiftGet.
	x _ leftX.
	[x < firstPixel] whileTrue:[
		tileFlag ifTrue:[
			ds _ self repeatValue: ds max: bmWidth << 16.
			dt _ self repeatValue: dt max: bmHeight << 16].
		xp _ ds // 16r10000.
		yp _ dt // 16r10000.
		tileFlag ifFalse:[
			xp _ self clampValue: xp max: bmWidth.
			yp _ self clampValue: yp max: bmHeight].
		(xp >= 0 and:[yp >= 0 and:[xp < bmWidth and:[yp < bmHeight]]]) ifTrue:[
			fillValue _ self bitmapValue: bmFill bits: bits atX: xp y: yp.
			fillValue _ (fillValue bitAnd: cMask) >> cShift.
			idx _ x >> baseShift.
			spanBuffer at: idx put: (spanBuffer at: idx) + fillValue.
		].
		ds _ ds + dsX.
		dt _ dt + dtX.
		x _ x + 1.
	].

	cMask _ (self aaColorMaskGet >> self aaShiftGet) bitOr: 16rF0F0F0F0.
	cShift _ self aaShiftGet.
	[x < lastPixel] whileTrue:[
		tileFlag ifTrue:[
			ds _ self repeatValue: ds max: bmWidth << 16.
			dt _ self repeatValue: dt max: bmHeight << 16].
		xp _ ds // 16r10000.
		yp _ dt // 16r10000.
		tileFlag ifFalse:[
			xp _ self clampValue: xp max: bmWidth.
			yp _ self clampValue: yp max: bmHeight].
		(xp >= 0 and:[yp >= 0 and:[xp < bmWidth and:[yp < bmHeight]]]) ifTrue:[
			fillValue _ self bitmapValue: bmFill bits: bits atX: xp y: yp.
			fillValue _ (fillValue bitAnd: cMask) >> cShift.
			idx _ x >> baseShift.
			spanBuffer at: idx put: (spanBuffer at: idx) + fillValue.
		].
		ds _ ds + (dsX << cShift).
		dt _ dt + (dtX << cShift).
		x _ x + aaLevel.
	].

	cMask _ self aaColorMaskGet.
	cShift _ self aaColorShiftGet.
	[x < rightX] whileTrue:[
		tileFlag ifTrue:[
			ds _ self repeatValue: ds max: bmWidth << 16.
			dt _ self repeatValue: dt max: bmHeight << 16].
		xp _ ds // 16r10000.
		yp _ dt // 16r10000.
		tileFlag ifFalse:[
			xp _ self clampValue: xp max: bmWidth.
			yp _ self clampValue: yp max: bmHeight].
		(xp >= 0 and:[yp >= 0 and:[xp < bmWidth and:[yp < bmHeight]]]) ifTrue:[
			fillValue _ self bitmapValue: bmFill bits: bits atX: xp y: yp.
			fillValue _ (fillValue bitAnd: cMask) >> cShift.
			idx _ x >> baseShift.
			spanBuffer at: idx put: (spanBuffer at: idx) + fillValue.
		].
		ds _ ds + dsX.
		dt _ dt + dtX.
		x _ x + 1.
	].
