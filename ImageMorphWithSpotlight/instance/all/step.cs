step
	| cp |
	((self bounds expandBy: spotBuffer extent // 2) containsPoint: (cp _ self cursorPoint))
		ifTrue:
		[(cp - (spotBuffer extent // 2)) = spotBuffer offset ifTrue: [^ self].  "No change"
		"Cursor has moved where its spotShape is visible"
		spotOn _ true.
		self spotChanged.
		spotBuffer offset: cp - (spotBuffer extent // 2).
		self spotChanged.
		(BitBlt current toForm: spotBuffer)
			"clear the buffer"
			fill: spotBuffer boundingBox fillColor: (Bitmap with: 0) rule: Form over;
			"Clip anything outside the base form"
			clipRect: (spotBuffer boundingBox
				intersect: (self bounds translateBy: spotBuffer offset negated));
			"Fill the spotBuffer with the spot image"
			copyForm: spotImage to: self position - spotBuffer offset rule: Form over;
			"Mask everything outside the spot shape to 0 (transparent)."
			copyForm: spotShape to: spotShape offset negated rule: Form and
				colorMap: (Bitmap with: 0 with: 16rFFFFFFFF)]
		ifFalse:
		[spotOn ifTrue: [self spotChanged. spotOn _ false]]