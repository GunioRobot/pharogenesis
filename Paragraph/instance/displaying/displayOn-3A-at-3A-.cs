displayOn: aDisplayMedium at: aPoint
	"Use internal clippingRect; destination cliping is done during actual display."

	self displayOn: aDisplayMedium at: aPoint
		clippingBox: (clippingRectangle translateBy: aPoint - compositionRectangle topLeft)
		rule: rule fillColor: mask