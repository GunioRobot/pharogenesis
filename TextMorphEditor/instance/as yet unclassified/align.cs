align
	"Align text according to the next greater alignment value,
	cycling among leftFlush, rightFlush, center, and justified."

	paragraph textStyle alignment: paragraph textStyle alignment + 1.
	self recomputeInterval