createDrawStateFor: aHand

	| pen state |
	pen _ Pen newOnForm: originalForm.
	state _ Array new: 4.
	state at: PenIndex put: pen.
	state at: PenSizeIndex put: 3.
	state at: PenColorIndex put: Color red.
	state at: LastMouseIndex put: nil.
	drawState at: aHand put: state.
