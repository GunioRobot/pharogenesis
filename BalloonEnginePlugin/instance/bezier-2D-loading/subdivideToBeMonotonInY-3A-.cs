subdivideToBeMonotonInY: index
	"Check if the given bezier curve is monoton in Y. If not, subdivide it"
	| startY viaY endY dy1 dy2 denom num |
	self inline: false.
	startY _ self bzStartY: index.
	viaY _ self bzViaY: index.
	endY _ self bzEndY: index.

	dy1 _ viaY - startY.
	dy2 _ endY - viaY.
	(dy1 * dy2) >= 0 ifTrue:[^index]. "Bezier is monoton"

	self incrementStat: GWBezierMonotonSubdivisions by: 1.
	"Compute split value"
	denom _ dy2 - dy1.
	num _ dy1.
	num < 0 ifTrue:[num _ 0 - num].
	denom < 0 ifTrue:[denom _ 0 - denom].
	^self computeBezier: index splitAt: (num asFloat / denom asFloat).