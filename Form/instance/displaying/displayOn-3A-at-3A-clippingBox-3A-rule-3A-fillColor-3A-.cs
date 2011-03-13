displayOn: aDisplayMedium at: aDisplayPoint clippingBox: clipRectangle rule: ruleInteger fillColor: aForm

	aDisplayMedium copyBits: self boundingBox
		from: self
		at: aDisplayPoint + self offset
		clippingBox: clipRectangle
		rule: ruleInteger
		fillColor: aForm