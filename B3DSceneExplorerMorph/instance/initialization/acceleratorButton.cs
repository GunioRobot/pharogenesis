acceleratorButton
	| outerButton aButton str miniWrapper aHelp |
	outerButton _ AlignmentMorph newRow height: 24.
	outerButton beTransparent.
	outerButton hResizing: #spaceFill; vResizing: #shrinkWrap.
	outerButton addMorph: (aButton _ UpdatingThreePhaseButtonMorph checkBox).
	aButton
		target: self;
		actionSelector: #toggleAcceleration;
		arguments: #();
		getSelector: #accelerationEnabled.

	outerButton addTransparentSpacerOfSize: (2 @ 0).
	str _ StringMorph contents: 'Enable hardware acceleration' font: nil. "(StrikeFont familyName: 'NewYork' size: 12)."
	miniWrapper _ AlignmentMorph newRow hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	miniWrapper beTransparent addMorphBack: str lock.
	outerButton addMorphBack: miniWrapper.
	aButton setBalloonText: (aHelp _ 'Turn on hardware acceleration if supported').
	miniWrapper setBalloonText: aHelp; setProperty: #balloonTarget toValue: aButton.
	^outerButton