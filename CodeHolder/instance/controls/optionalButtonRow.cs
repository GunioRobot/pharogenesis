optionalButtonRow
	"Answer a row of control buttons"

	| aRow aButton aLabel |
	aRow _ AlignmentMorph newRow.
	aRow setNameTo: 'buttonPane'.
	aRow beSticky.
	aRow hResizing: #spaceFill.
	aRow wrapCentering: #center; cellPositioning: #leftCenter.
	aRow clipSubmorphs: true.
	aRow cellInset: 3.
	Preferences menuButtonInToolPane
		ifTrue:
			[aRow addMorphFront: self menuButton].

	self optionalButtonPairs  do:
		[:tuple |
			aButton _ PluggableButtonMorph
				on: self
				getState: nil
				action: tuple second.
			aButton 
				useRoundedCorners;
				hResizing: #spaceFill;
				vResizing: #spaceFill;
				onColor: Color transparent offColor: Color transparent.
			aLabel _ Preferences abbreviatedBrowserButtons 
				ifTrue: [self abbreviatedWordingFor: tuple second]
				ifFalse: [nil].
			aButton label: (aLabel ifNil: [tuple first asString])
				" font: (StrikeFont familyName: 'Atlanta' size: 9)".
			tuple size > 2 ifTrue: [aButton setBalloonText: tuple third].
			tuple size > 3 ifTrue: [aButton triggerOnMouseDown: tuple fourth].
			aRow addMorphBack: aButton].

	aRow addMorphBack: self codePaneProvenanceButton.
	^ aRow