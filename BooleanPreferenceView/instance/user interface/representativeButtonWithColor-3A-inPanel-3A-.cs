representativeButtonWithColor: aColor inPanel: aPreferencesPanel
	"Return a button that controls the setting of prefSymbol.  It will keep up to date even if the preference value is changed in a different place"

	| outerButton aButton str miniWrapper |
	
	outerButton := AlignmentMorph newRow height: 24.
	outerButton color:  (aColor ifNil: [Color r: 0.645 g: 1.0 b: 1.0]).
	outerButton hResizing: (aPreferencesPanel ifNil: [#shrinkWrap] ifNotNil: [#spaceFill]).
	outerButton vResizing: #shrinkWrap.
	outerButton addMorph: (aButton := UpdatingThreePhaseButtonMorph checkBox).
	aButton
		target: self preference;
		actionSelector: #togglePreferenceValue;
		getSelector: #preferenceValue.

	outerButton addTransparentSpacerOfSize: (2 @ 0).
	str := StringMorph contents: self preference name font: (StrikeFont familyName: 'NewYork' size: 12).

	self preference localToProject ifTrue:
		[str emphasis: TextEmphasis bold emphasisCode].

	miniWrapper := AlignmentMorph newRow hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	miniWrapper beTransparent addMorphBack: str lock.
	aPreferencesPanel
		ifNotNil:  "We're in a Preferences panel"
			[miniWrapper on: #mouseDown send: #offerPreferenceNameMenu:with:in: to: self withValue: aPreferencesPanel.
			miniWrapper on: #mouseEnter send: #menuButtonMouseEnter: to: miniWrapper.
			miniWrapper on: #mouseLeave send: #menuButtonMouseLeave: to: miniWrapper.
			miniWrapper setBalloonText: 'Click here for a menu of options regarding this preference.  Click on the checkbox to the left to toggle the setting of this preference']

		ifNil:  "We're a naked button, not in a panel"
			[miniWrapper setBalloonText: self preference helpString; setProperty: #balloonTarget toValue: aButton].

	outerButton addMorphBack: miniWrapper.
	outerButton setNameTo: self preference name.

	aButton setBalloonText: self preference helpString.

	^ outerButton

	"(Preferences preferenceAt: #balloonHelpEnabled) view tearOffButton"