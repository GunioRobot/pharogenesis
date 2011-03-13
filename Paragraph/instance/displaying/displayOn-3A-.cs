displayOn: aDisplayMedium
	"Because Paragraphs cache so much information, computation is avoided
	and displayAt: 0@0 is not appropriate here."

	self displayOn: aDisplayMedium
		at: compositionRectangle topLeft
		clippingBox: clippingRectangle
		rule: rule
		fillColor: mask