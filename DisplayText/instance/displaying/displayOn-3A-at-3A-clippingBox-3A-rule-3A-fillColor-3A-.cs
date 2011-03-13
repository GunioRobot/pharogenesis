displayOn: aDisplayMedium at: aDisplayPoint clippingBox: clipRectangle rule: ruleInteger fillColor: aForm 
	"Refer to the comment in 
	DisplayObject|displayOn:at:clippingBox:rule:mask:."

	self form
		displayOn: aDisplayMedium
		at: aDisplayPoint + offset
		clippingBox: clipRectangle
		rule: ruleInteger
		fillColor: aForm