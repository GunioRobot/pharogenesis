sourceForm: aForm
	(aForm depth = 1 and: [destForm depth > 1])
		ifTrue: ["Map 1-bit source to all ones for color mask"
				colorMap _ Bitmap with: 0 with: 16rFFFFFFFF]
		ifFalse: [colorMap _ nil].
	^ super sourceForm: aForm