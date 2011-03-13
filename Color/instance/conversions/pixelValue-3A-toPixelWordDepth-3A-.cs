pixelValue: val toPixelWordDepth: depth
	"convert to a 32 bit quantity.  Covers 32//depth pixels. 6/14/96 tk"
	| d word |
	d _ depth.
	word _ val.
	[d >= 32] whileFalse: [
		word _ word bitOr: (word bitShift: d).
		d _ d+d].
	^ word
