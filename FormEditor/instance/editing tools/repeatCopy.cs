repeatCopy
	"As long as the red button is pressed, copy the source form onto the 
	display screen."

	[sensor redButtonPressed]
		whileTrue: 
		[(BitBlt current destForm: Display sourceForm: form halftoneForm: color
			combinationRule: (Display depth > 1 ifTrue: [Form paint]
										ifFalse: [mode])
			destOrigin: self cursorPoint sourceOrigin: 0@0 extent: form extent
			clipRect: view insetDisplayBox)
			colorMap: (Bitmap with: 0 with: 16rFFFFFFFF);
			copyBits]