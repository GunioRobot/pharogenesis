displayOn: aDisplayMedium transformation: aTransformation clippingBox: clipRect rule: anInteger fillColor: aForm

	| transformedPath newCurve |
	transformedPath _ aTransformation applyTo: self.
	newCurve _ Curve new.
	newCurve firstPoint: transformedPath firstPoint.
	newCurve secondPoint: transformedPath secondPoint.
	newCurve thirdPoint: transformedPath thirdPoint.
	newCurve form: self form.
	newCurve
		displayOn: aDisplayMedium
		at: 0 @ 0
		clippingBox: clipRect
		rule: anInteger
		fillColor: aForm