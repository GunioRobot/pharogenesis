asForm
	"Answer a Form made up of the bits that represent the receiver's 
	displayable text."
	| aForm |
	aForm _ Form extent: compositionRectangle extent.
	self displayOn: aForm
		at: 0 @ 0
		clippingBox: aForm boundingBox
		rule: Form over
		fillColor: nil.
	aForm offset: offset.
	^ aForm