revert

	self form: (formToEdit magnify: formToEdit boundingBox by: magnification).
	brush _ Pen newOnForm: originalForm.
	brush squareNib: brushSize.
	brush color: brushColor.
