setStripeColorsFrom: paneColor
	self isActive
		ifTrue: [stripes second color: paneColor;
					borderColor: stripes second color darker.
				stripes first color: stripes second borderColor darker;
					borderColor: stripes first color darker]
		ifFalse: ["This could be much faster"
				stripes second color: paneColor; borderColor: paneColor.
				stripes first color: paneColor; borderColor: paneColor].
