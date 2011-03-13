addLowerLeftButtonsTo: aPasteUpMorph

"save button disabled for now"
"	delta _ 40 @ 0.
	aPosition _ aPosition + delta.
	aButton _ SimpleButtonMorph new label: 'Save';
			setProperty: #eToyControl toValue: true.
	aButton target: eToyHolder playfield primaryHand; actionSelector: #saveEToyInFile;
		position: aPosition.
	aPasteUpMorph addMorphBack: aButton."
