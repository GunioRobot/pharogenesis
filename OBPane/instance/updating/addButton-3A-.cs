addButton: aButton
	self hasButton ifTrue: [self removeMorph: button].
	button _ aButton.
	button height: self defaultButtonHeight.
	self 
		addMorph: button;
		adjustList;
		adjustButton