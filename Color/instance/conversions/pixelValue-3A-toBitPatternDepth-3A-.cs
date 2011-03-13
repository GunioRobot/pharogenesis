pixelValue: val toBitPatternDepth: depth
	"convert to a 32 bit quantity.  Covers 32//depth pixels. Dan's method 6/22/96 tk"

	depth = 32 ifTrue: [^ Bitmap with: val].
	^ Bitmap with: ((val bitAnd: (1 bitShift: depth) - 1) * 
		(#(16rFFFFFFFF  "replicate for every bit"
			16r55555555 -	"2 bits"
			16r11111111 - - -  "4 bits"
			16r01010101 - - - - - - -  "8 bits"
			16r00010001) at: depth))

"The above gives the same result as this explanation:
	| d word |
	d _ depth.
	word _ val.
	[d >= 32] whileFalse: [
		word _ word bitOr: (word bitShift: d).
		d _ d+d].
	^ Bitmap with: word
"