displayOn: aDisplayMedium transformation: aTransformation clippingBox: clipRect rule: anInteger fillColor: aForm

	| transformedPath newCurveFitter |
	transformedPath _ aTransformation applyTo: self.
	newCurveFitter _ CurveFitter new.
	newCurveFitter firstPoint: transformedPath firstPoint.
	newCurveFitter secondPoint: transformedPath secondPoint.
	newCurveFitter thirdPoint: transformedPath thirdPoint.
	newCurveFitter form: self form.
	newCurveFitter
		displayOn: aDisplayMedium
		at: 0 @ 0
		clippingBox: clipRect
		rule: anInteger
		fillColor: aForm