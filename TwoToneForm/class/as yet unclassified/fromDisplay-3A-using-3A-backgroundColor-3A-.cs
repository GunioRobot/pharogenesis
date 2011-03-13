fromDisplay: aRectangle using: oldForm backgroundColor: backColor
	"Like fromDisplay: only if oldForm is the right size, copy into it and answer it instead."

	((oldForm ~~ nil) and: [oldForm extent = aRectangle extent])
		ifTrue: [oldForm fromDisplay: aRectangle.
			 	^ oldForm]
		ifFalse: [^ self fromDisplay: aRectangle
					using: ((self extent: aRectangle extent depth: 1)
								foregroundColor: Display black
								backgroundColor: backColor)]