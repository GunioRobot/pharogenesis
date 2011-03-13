copyBits
	"Primitive. Perform the movement of bits from the source form to the 
	destination form. Fail if any variables are not of the right type (Integer 
	or Form) or if the combination rule is not between 0 and 15 inclusive. 
	Set the variables and try again (BitBlt|copyBitsAgain, also a Primitive). 
	Essential. See Object documentation whatIsAPrimitive."
	<primitive: 96>
	combinationRule = Form paint ifTrue: [^ self paintBits].
	combinationRule = Form erase1bitShape ifTrue: [^ self eraseBits].
	destX _ destX asInteger.
	destY _ destY asInteger.
	width _ width asInteger.
	height _ height asInteger.
	sourceX _ sourceX asInteger.
	sourceY _ sourceY asInteger.
	clipX _ clipX asInteger.
	clipY _ clipY asInteger.
	clipWidth _ clipWidth asInteger.
	clipHeight _ clipHeight asInteger.
	^ self copyBitsAgain