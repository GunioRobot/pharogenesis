+ aColor
	"Answer this color mixed with the given color. Additive color mixing.  6/18/96 tk"

	^ Color
		red: ((self red + aColor red) min: 1.0 max: 0.0)
		green: ((self green + aColor green) min: 1.0 max: 0.0)
		blue: ((self blue + aColor  blue) min: 1.0 max: 0.0)
