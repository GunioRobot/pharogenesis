displayOn: aDisplayMedium transformation: displayTransformation clippingBox: clipRectangle align: alignmentPoint with: relativePoint rule: ruleInteger fillColor: aForm 
	"Refer to the comment in 
	DisplayObject|displayOn:transformation:clippingBox:align:with:rule:mask:."

	| absolutePoint |
	absolutePoint _ displayTransformation applyTo: relativePoint.
	absolutePoint _ absolutePoint x asInteger @ absolutePoint y asInteger.
	self displayOn: aDisplayMedium
		at: absolutePoint - alignmentPoint
		clippingBox: clipRectangle
		rule: ruleInteger
		fillColor: aForm