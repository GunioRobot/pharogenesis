fillBitmapSpan: bmFill from: leftX to: rightX at: yValue
	| x x1 dsX ds dtX dt deltaX deltaY bits xp yp bmWidth bmHeight fillValue tileFlag |
	self inline: false.
	self var: #bits declareC:'int *bits'.
	self aaLevelGet = 1
		ifFalse:[^self fillBitmapSpanAA: bmFill from: leftX to: rightX at: yValue].

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

	x _ leftX.
	x1 _ rightX.
	[x < x1] whileTrue:[
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
			spanBuffer at: x put: fillValue.
		].
		ds _ ds + dsX.
		dt _ dt + dtX.
		x _ x + 1.
	].