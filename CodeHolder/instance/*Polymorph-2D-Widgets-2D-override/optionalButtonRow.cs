optionalButtonRow
	"Answer a row of control buttons"
	
	| buttons aLabel |
	buttons := OrderedCollection new.
	Preferences menuButtonInToolPane
		ifTrue: [buttons add: self menuButton].
	self optionalButtonPairs
		do: [:tuple |
			aLabel := Preferences abbreviatedBrowserButtons
				ifTrue: [self abbreviatedWordingFor: tuple second].
			buttons add: ((PluggableButtonMorph
					on: self
					getState: nil
					action: tuple second)
				hResizing: #spaceFill;
				vResizing: #spaceFill;
				label: (aLabel ifNil: [tuple first asString]);
				setBalloonText: (tuple size > 2 ifTrue: [tuple third]);
				triggerOnMouseDown: (tuple size > 3
					ifTrue: [tuple fourth]
					ifFalse: [false]))].
	buttons add: self codePaneProvenanceButton.
	^(UITheme builder newRow:  buttons)
		setNameTo: 'buttonPane';
		cellInset: 2