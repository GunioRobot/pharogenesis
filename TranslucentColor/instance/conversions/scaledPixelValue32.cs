scaledPixelValue32
	"Return the alpha scaled pixel value for depth 32"
	| pv32 a b g r |
	pv32 _ super scaledPixelValue32.
	a _ (self alpha * 255.0) rounded.
	b _ (pv32 bitAnd: 255) * a // 256.
	g _ ((pv32 bitShift: -8) bitAnd: 255) * a // 256.
	r _ ((pv32 bitShift: -16) bitAnd: 255) * a // 256.
	^b + (g bitShift: 8) + (r bitShift: 16) + (a bitShift: 24)