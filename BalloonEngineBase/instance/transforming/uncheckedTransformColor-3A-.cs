uncheckedTransformColor: fillIndex
	| r g b a transform |
	self var: #transform declareC:'float *transform'.
	(self hasColorTransform) ifFalse:[^fillIndex].
	b _ fillIndex bitAnd: 255.
	g _ (fillIndex >> 8) bitAnd: 255.
	r _ (fillIndex >> 16) bitAnd: 255.
	a _ (fillIndex >> 24) bitAnd: 255.
	transform _ self colorTransform.
	r _ (r * (transform at: 0) + (transform at: 1)) asInteger.
	g _ (g * (transform at: 2) + (transform at: 3)) asInteger.
	b _ (b * (transform at: 4) + (transform at: 5)) asInteger.
	a _ (a * (transform at: 6) + (transform at: 7)) asInteger.
	r _ r max: 0. r _ r min: 255.
	g _ g max: 0. g _ g min: 255.
	b _ b max: 0. b _ b min: 255.
	a _ a max: 0. a _ a min: 255.
	a < 16 ifTrue:[^0]."ALWAYS return zero for transparent fills"
	^b + (g << 8) + (r << 16) + (a << 24)