changeBackgroundColor

	| colorPicker |
	colorPicker _ self changeColorTarget: self world selector: #color:.
	colorPicker updateContinuously: false.
