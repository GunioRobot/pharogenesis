color: aColor
	"For backwards compatibility with GradientFillMorph"

	self flag: #fixThis.
	self removeProperty: #fillStyle.
	^ super color: aColor