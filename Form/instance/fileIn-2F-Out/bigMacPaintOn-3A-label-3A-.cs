bigMacPaintOn: stream label: labelDisplayBox
	| form |
	form _ Form extent: (width max: labelDisplayBox width) @ (height + labelDisplayBox height).
	form copy: (0@0 extent: labelDisplayBox extent)
		from: labelDisplayBox topLeft
		in: Display rule: Form over.
	form copy: (0@labelDisplayBox height extent: self extent)
		from: 0@0
		in: self rule: Form over.
	form bigMacPaintOn: stream