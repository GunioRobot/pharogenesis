buttonRow: specArray
	| aRow aButton state |
	aRow := AlignmentMorph newRow.
	aRow 
		color: (Display depth <= 8 ifTrue: [Color transparent] ifFalse: [Color gray alpha: 0.2]);
		borderWidth: 0.

	aRow hResizing: #spaceFill; vResizing: #spaceFill; rubberBandCells: true.
	aRow clipSubmorphs: true.
	aRow layoutInset: 2@2; cellInset: 1; color: Color white.
	aRow wrapCentering: #center; cellPositioning: #leftCenter.
	specArray do:
		[:triplet |
			state := triplet at: 5 ifAbsent: [#buttonState].
			aButton := PluggableButtonMorph
				on: self
				getState: state
				action: #performButtonAction:enabled:.
			aButton
				hResizing: #spaceFill;
				vResizing: #spaceFill;
				label: triplet first asString;
				arguments: (Array with: triplet second with: (triplet at: 4 ifAbsent: [#buttonEnabled])); 
				onColor: Color white offColor: Color white.
			aRow addMorphBack: aButton.
			aButton setBalloonText: triplet third].
	^ aRow