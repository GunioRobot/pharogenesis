magnification: aNumber

	| oldPenSize oldForm |
	oldPenSize _ brushSize / magnification.
	oldForm _ self form shrink: self form boundingBox by: magnification.
	magnification _ aNumber asInteger max: 1.
	self form: (oldForm magnify: oldForm boundingBox by: magnification).
	brush _ Pen newOnForm: originalForm.
	self penSize: oldPenSize.
	brush color: brushColor.
