paintBits
	"Perform the paint operation, which requires two calls to BitBlt."
	| color oldMap saveRule |
	sourceForm depth = 1 ifFalse: 
		[^ self halt: 'paint operation is only defined for 1-bit deep sourceForms'].
	saveRule _ combinationRule.
	color _ halftoneForm.  halftoneForm _ nil.
	oldMap _ colorMap.
	"Map 1's to ALL ones, not just one"
	self colorMap: (Bitmap with: 0 with: 16rFFFFFFFF).
	combinationRule _ Form erase.
	self copyBits. 		"Erase the dest wherever the source is 1"
	halftoneForm _ color.
	combinationRule _ Form under.
	self copyBits.	"then OR, with whatever color, into the hole"
	colorMap _ oldMap.
	combinationRule _ saveRule

"(Form dotOfSize: 32)
	displayOn: Display
	at: Sensor cursorPoint
	clippingBox: Display boundingBox
	rule: Form paint
	mask: Form lightGray"