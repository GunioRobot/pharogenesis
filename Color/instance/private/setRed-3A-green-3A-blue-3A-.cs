setRed: r green: g blue: b
	"Initialize this color's r, g, and b components to the given values in [0.0..1.0].  Encoded in a single variable as 3 integers [0..1023].
	A color is essentially immutable.  Once you set red, green, and blue, you cannot change them.  Instead, create a new Color and use it.
	6/18/96 tk"

	rgb == nil ifFalse: [^ self error: 'Can''t change a Color.  Please make a new one'].
	rgb _
		(((r * ComponentMax) rounded bitAnd: ComponentMask) bitShift: RedShift) +
		(((g * ComponentMax) rounded bitAnd: ComponentMask) bitShift: GreenShift) +
		 ((b * ComponentMax) rounded bitAnd: ComponentMask)