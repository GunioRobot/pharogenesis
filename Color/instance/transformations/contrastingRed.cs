contrastingRed
	"If I am not redish, return red to contrast with me. If I am too red, return green"

	self red < 0.5 ifTrue: [^ Color red].
	self red > (self green + (self blue * 0.5)) ifTrue: [^ Color green].
	^ Color red
