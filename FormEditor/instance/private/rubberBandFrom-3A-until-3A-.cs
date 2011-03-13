rubberBandFrom: startPoint until: aBlock

	| endPoint previousEndPoint |
	previousEndPoint _ startPoint.
	[aBlock value] whileFalse:
		[(endPoint _ self cursorPoint) = previousEndPoint 
			ifFalse:
			[(Line from: startPoint to: previousEndPoint withForm: form)
				displayOn: Display
				at: 0 @ 0
				clippingBox: view insetDisplayBox
				rule: Form reverse
				fillColor: Display black.
			(Line from: startPoint to: endPoint withForm: form)
				displayOn: Display
				at: 0 @ 0
				clippingBox: view insetDisplayBox
				rule: Form reverse
				fillColor: Display black.
			previousEndPoint  _ endPoint]].
	(Line from: startPoint to: previousEndPoint withForm: form)
		displayOn: Display
		at: 0 @ 0
		clippingBox: view insetDisplayBox
		rule: Form reverse
		fillColor: Display black.
	^endPoint