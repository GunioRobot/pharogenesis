clear

	self form: ((Form extent: 400@300 depth: 8) fillColor: color).
	brush _ Pen newOnForm: originalForm.
	brush roundNib: brushSize.
	brush color: brushColor.
