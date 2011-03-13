displayOn: aDisplayMedium at: aPoint clippingBox: clipRect rule: anInteger fillColor: aForm

	| nSegments line angle sin cos xn yn xn1 yn1 |
	nSegments _ 12.0.
	line _ Line new.
	line form: self form.
	angle _ 90.0 / nSegments.
	sin _ (angle * (2 * Float pi / 360.0)) sin.
	cos _ (angle * (2 * Float pi / 360.0)) cos.
	quadrant = 1
		ifTrue: 
			[xn _ radius asFloat.
			yn _ 0.0].
	quadrant = 2
		ifTrue: 
			[xn _ 0.0.
			yn _ 0.0 - radius asFloat].
	quadrant = 3
		ifTrue: 
			[xn _ 0.0 - radius asFloat.
			yn _ 0.0].
	quadrant = 4
		ifTrue: 
			[xn _ 0.0.
			yn _ radius asFloat].
	nSegments asInteger
		timesRepeat: 
			[xn1 _ xn * cos + (yn * sin).
			yn1 _ yn * cos - (xn * sin).
			line beginPoint: center + (xn asInteger @ yn asInteger).
			line endPoint: center + (xn1 asInteger @ yn1 asInteger).
			line
				displayOn: aDisplayMedium
				at: aPoint
				clippingBox: clipRect
				rule: anInteger
				fillColor: aForm.
			xn _ xn1.
			yn _ yn1]