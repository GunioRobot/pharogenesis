transformColor: fillIndex
	| r g b a transform alphaScale |
	self var: #transform declareC:'float *transform'.
	self var: #alphaScale declareC:'double alphaScale'.
	(fillIndex = 0 or:[self isFillColor: fillIndex]) ifFalse:[^fillIndex].
	b _ fillIndex bitAnd: 255.
	g _ (fillIndex >> 8) bitAnd: 255.
	r _ (fillIndex >> 16) bitAnd: 255.
	a _ (fillIndex >> 24) bitAnd: 255.
	(self hasColorTransform) ifTrue:[
		transform _ self colorTransform.
		alphaScale _ (a * (transform at: 6) + (transform at: 7)) / a.
		r _ (r * (transform at: 0) + (transform at: 1) * alphaScale) asInteger.
		g _ (g * (transform at: 2) + (transform at: 3) * alphaScale) asInteger.
		b _ (b * (transform at: 4) + (transform at: 5) * alphaScale) asInteger.
		a _ a * alphaScale.
		r _ r max: 0. r _ r min: 255.
		g _ g max: 0. g _ g min: 255.
		b _ b max: 0. b _ b min: 255.
		a _ a max: 0. a _ a min: 255.
	].
	a < 1 ifTrue:[^0]."ALWAYS return zero for transparent fills"
	"If alpha is not 255 (or close thereto) then we need to flush the engine before proceeding"
	(a < 255 and:[self needsFlush]) 
		ifTrue:[self stopBecauseOf: GErrorNeedFlush].
	^b + (g << 8) + (r << 16) + (a << 24)