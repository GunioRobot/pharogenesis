isInf
	"simple, byte-order independent test for +/- Infinity"

	^ self = (self * 1.5 + 1.0)