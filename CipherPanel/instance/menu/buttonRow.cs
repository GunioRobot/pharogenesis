buttonRow
	| row aButton |
	row := AlignmentMorph newRow color: self color;
				 hResizing: #shrinkWrap;
				 vResizing: #shrinkWrap.
	#('show help' 'show hints' 'clear typing' 'enter a new cipher' 'quote from Squeak' )
		with: #(#showHelpWindow #showHintsWindow #clearTyping #enterANewCipher #squeakCipher )
		do: [:label :selector | 
			aButton := SimpleButtonMorph new target: self.
			aButton color: Color transparent;
				 borderWidth: 1;
				 borderColor: Color black.
			aButton actionSelector: selector.
			aButton label: label translated.
			row addMorphBack: aButton.
			row addTransparentSpacerOfSize: 3 @ 0].
	^ row