clear

	| newPen |
	self form: ((Form extent: 400@300 depth: 8) fillColor: color).
	drawState do: [:state |
		newPen _ Pen newOnForm: originalForm.
		newPen roundNib: (state at: PenSizeIndex).
		newPen color: (state at: PenColorIndex).
		state at: PenIndex put: newPen].
