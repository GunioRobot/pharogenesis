addOptionalHandlesTo: aHalo box: box
	| aHandle |
	aHandle _ aHalo addHandleAt: box bottomLeft color: Color lightGreen.
	aHandle on: #mouseDown send: #chooseFont to: self.

	aHandle _ aHalo addHandleAt: (box bottomLeft + (20@0)) color: Color lightRed.
	aHandle on: #mouseDown send: #chooseStyle to: self.

	aHandle _ aHalo addHandleAt: (box bottomLeft + (40@0)) color: Color lightBrown.
	aHandle on: #mouseDown send: #chooseEmphasis to: self.

