color24
	"Color from 3 bytes"
	| red green blue |
	red := source next.
	green := source next.
	blue := source next.
	^Color
		r: red / 255.0 
		g: green / 255.0
		b: blue / 255.0