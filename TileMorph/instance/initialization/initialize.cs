initialize

	super initialize.
	self typeColor: (Color r: 0.8 g: 1.0 b: 0.6).
	self borderWidth: 1.
	type _ #literal.  "#literal, #slotRef, #objRef, #operator, #expression"
	slotName _ ''.
	literal _ 1.
