extent: extentPoint fromStipple: fourNibbles
	"Answer an instance of me with bitmap initialized from
	a repeating 4x4 bit stipple encoded in a 16-bit constant."
	| nibble |
	^ (self extent: extentPoint depth: 1)
		initFromArray: ((1 to: 4) collect:
				[:i | nibble := (fourNibbles bitShift: -4*(4-i)) bitAnd: 16rF.
				16r11111111 * nibble])  "fill 32 bits with each 4-bit nibble"
