arrowLength: aLength
	"Assumes that I have exactly two vertices"

	| theta horizontalOffset verticalOffset newTip delta |
	delta _ vertices second - vertices first.
	theta _ delta theta.
	horizontalOffset _ aLength * (theta cos).
	verticalOffset _ aLength * (theta sin).
	newTip _ vertices first + (horizontalOffset @ verticalOffset).
	self verticesAt: 2 put: newTip