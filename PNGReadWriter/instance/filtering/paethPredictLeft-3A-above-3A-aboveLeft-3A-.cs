paethPredictLeft: a above: b aboveLeft: c
	"Predicts the value of a pixel based on nearby pixels, based on
Paeth (GG II, 1991)"

	| p pa pb pc |
	p _ a + b - c .
	pa _ (p - a) abs.
	pb _ (p - b) abs.
	pc _ (p - c) abs.
	((pa <= pb) and: [pa <= pc]) ifTrue: [^ a].
	(pb <= pc) ifTrue: [^ b].
	^ c
