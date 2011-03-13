positionText

	| box |
	box _ (self displayBox insetBy: 6@6) origin extent: editParagraph boundingBox extent.
	editParagraph wrappingBox: box clippingBox: box.
	self centerText