clear

	self form: ((Form extent: 125@100 depth: 8) fillColor: color).
	brush _ Pen newOnForm: originalForm.
	brush roundNib: brushSize.
	brush color: brushColor.
