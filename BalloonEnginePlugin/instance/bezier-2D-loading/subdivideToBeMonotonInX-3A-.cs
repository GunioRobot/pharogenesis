subdivideToBeMonotonInX: index
	"Check if the given bezier curve is monoton in X. If not, subdivide it"
	| denom num startX viaX endX dx1 dx2 |
	self inline: false.
	startX _ self bzStartX: index.
	viaX _ self bzViaX: index.
	endX _ self bzEndX: index.

	dx1 _ viaX - startX.
	dx2 _ endX - viaX.
	(dx1 * dx2) >= 0 ifTrue:[^index]. "Bezier is monoton"

	self incrementStat: GWBezierMonotonSubdivisions by: 1.
	"Compute split value"
	denom _ dx2 - dx1.
	num _ dx1.
	num < 0 ifTrue:[num _ 0 - num].
	denom < 0 ifTrue:[denom _ 0 - denom].
	^self computeBezier: index splitAt: (num asFloat / denom asFloat).