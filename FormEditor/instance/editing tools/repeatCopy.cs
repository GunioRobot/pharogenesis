repeatCopy
	"As long as the red button is pressed, copy the source form onto the 
	display screen."
  | drawingWasChanged |
	drawingWasChanged := false.
	[sensor redButtonPressed]
		whileTrue: 
		[(BitBlt current destForm: Display sourceForm: form halftoneForm: color
			combinationRule: (Display depth > 1 ifTrue: [mode ~= Form erase ifTrue: [Form paint] ifFalse: [mode]]
										ifFalse: [mode])
			destOrigin: self cursorPoint sourceOrigin: 0@0 extent: form extent
			clipRect: view insetDisplayBox)
			colorMap: (Bitmap with: 0 with: 16rFFFFFFFF);
			copyBits.
		  drawingWasChanged := true.
		].
	drawingWasChanged
	  ifTrue: [hasUnsavedChanges contents: true.]