interpolateTo: end at: amountDone
	"Return the color vector yielded by interpolating from the state of the object to the specified end state at the specified amount done"

	| newColor r g b a |
	r _ self red.
	g _ self green.
	b _ self blue.
	a _ self alpha.

	newColor _ B3DColor4 new.
	newColor red: r + (((end red) - r) * amountDone).
	newColor green: g + (((end green) - g) * amountDone).
	newColor blue: b + (((end blue) - b) * amountDone).
	newColor alpha: a + (((end alpha) - a) * amountDone).

	^ newColor.
