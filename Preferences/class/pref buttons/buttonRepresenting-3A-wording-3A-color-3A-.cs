buttonRepresenting: prefSymbol wording: aString color: aColor
	"self currentHand attachMorph: (Preferences buttonRepresenting: #balloonHelpEnabled wording: 'Balloon Help' color: nil)"
	"Return a button that controls the setting of prefSymbol.  It will keep up to date even if the preference value is changed in a different place"
	| outerButton aButton str aHelp miniWrapper |
	(FlagDictionary includesKey: prefSymbol) ifFalse: [self error: 'Unknown preference: ', prefSymbol printString].
	outerButton _ AlignmentMorph newRow height: 24.
	outerButton color:  (aColor ifNil: [Color r: 0.645 g: 1.0 b: 1.0]).
	outerButton hResizing: #spaceFill; vResizing: #shrinkWrap.
	outerButton addMorph: (aButton _ UpdatingThreePhaseButtonMorph checkBox).
	aButton
		target: self;
		actionSelector: #togglePreference:;
		arguments: (Array with: prefSymbol);
		target: Preferences;
		getSelector: prefSymbol.

	outerButton addTransparentSpacerOfSize: (2 @ 0).
	str _ StringMorph contents: aString font: (StrikeFont familyName: 'NewYork' size: 12).
	miniWrapper _ AlignmentMorph newRow hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	miniWrapper beTransparent addMorphBack: str lock.
	outerButton addMorphBack: miniWrapper.
	aButton setBalloonText: (aHelp _ Preferences helpMessageForPreference: prefSymbol).
	miniWrapper setBalloonText: aHelp; setProperty: #balloonTarget toValue: aButton.

	^ outerButton