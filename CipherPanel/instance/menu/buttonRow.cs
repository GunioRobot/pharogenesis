buttonRow

	| row aButton |
	row _ AlignmentMorph newRow
		color: self color;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap.
	aButton _ SimpleButtonMorph new target: self.
	aButton color: Color transparent; borderWidth: 1; borderColor: Color black.

	#('show help' 'show hints' 'clear typing' 'enter a new cipher')
	with: 
	#(showHelpWindow showHintsWindow clearTyping enterANewCipher)
	do: [:label :selector |
		aButton _ aButton fullCopy.
		aButton actionSelector: selector.
		aButton label: label.
		row addMorphBack: aButton.
		row addTransparentSpacerOfSize: (3 @ 0)].

	^ row
