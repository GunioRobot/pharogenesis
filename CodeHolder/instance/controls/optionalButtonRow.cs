optionalButtonRow
	"Answer a row of control buttons"
	| aRow aButton aLabel |
	aRow := AlignmentMorph newRow.
	aRow setNameTo: 'buttonPane'.
	aRow beSticky.
	aRow hResizing: #spaceFill.
	aRow wrapCentering: #center;
		 cellPositioning: #leftCenter.
	aRow clipSubmorphs: true.
	aRow cellInset: 1.
	aRow color: Color white.
	Preferences menuButtonInToolPane
		ifTrue: [aRow addMorphFront: self menuButton].
	self optionalButtonPairs
		do: [:tuple | 
			aButton := PluggableButtonMorph
						on: self
						getState: nil
						action: tuple second.
			aButton hResizing: #spaceFill;
				 vResizing: #spaceFill;
				 onColor: Color white offColor: Color white.
			aLabel := Preferences abbreviatedBrowserButtons
						ifTrue: [self abbreviatedWordingFor: tuple second].
			aButton
				label: (aLabel
						ifNil: [tuple first asString]).
			tuple size > 2
				ifTrue: [aButton setBalloonText: tuple third].
			tuple size > 3
				ifTrue: [aButton triggerOnMouseDown: tuple fourth].
			aRow addMorphBack: aButton].
	aRow addMorphBack: self codePaneProvenanceButton.
	^ aRow