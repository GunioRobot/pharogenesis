drawOn: aCanvas

	super drawOn: aCanvas.
	spotOn ifTrue:
		[aCanvas paintImage: spotBuffer at: spotBuffer offset].
