gradientFillColor: aColor
	"For backwards compatibility with GradientFillMorph"

	self flag: #fixThis.
	self useGradientFill.
	self fillStyle colorRamp: {0.0 -> color. 1.0 -> aColor}.
	self changed
