deleteRubberBandFrom: startPoint to: endPoint

	(Line from: startPoint to: endPoint withForm: form)
		displayOn: Display
		at: 0 @ 0
		clippingBox: view insetDisplayBox
		rule: Form reverse
		fillColor: (Display depth = 1 ifTrue: [Color black] ifFalse: [Color gray]).