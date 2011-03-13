addButtonRow

	| b spacer buttonRow |
	b _ SimpleButtonMorph new target: self; color: Color veryLightGray.
	spacer _ AlignmentMorph newSpacer: self color.
	buttonRow _ AlignmentMorph newRow
		borderWidth: 0;
		inset: 3;
		color: self color;
		width: self innerBounds width;
		hResizing: #spaceFill;
		vResizing: #shrinkWrap;
		position: self innerBounds left@self lastSubmorph bottom.
	buttonRow
		addMorphBack: spacer fullCopy;
		addMorphBack: (b fullCopy label: 'Accept(s)'; actionSelector: #accept);
		addMorphBack: spacer fullCopy;
		addMorphBack: (b fullCopy label: 'Cancel(l)'; actionSelector: #cancel);
		addMorphBack: spacer fullCopy.
	self addMorphBack: buttonRow.
