buttonRow: specArray
	| aRow aButton state |
	aRow _ AlignmentMorph newRow.
	aRow 
		color: (Display depth <= 8 ifTrue: [Color transparent] ifFalse: [Color gray alpha: 0.2]);
		borderWidth: 0.

	aRow hResizing: #spaceFill; vResizing: #spaceFill; rubberBandCells: true.
	aRow clipSubmorphs: true.
	aRow layoutInset: 5@2; cellInset: 3.
	aRow wrapCentering: #center; cellPositioning: #leftCenter.
	specArray do:
		[:triplet |
			state _ triplet at: 4 ifAbsent: [#buttonState].
			aButton _ PluggableButtonMorph
				on: self
				getState: state
				action: #performButtonAction:enabled:.
			aButton
				hResizing: #spaceFill;
				vResizing: #spaceFill;
				useRoundedCorners;
				label: triplet first asString;
				arguments: (Array with: triplet second with: state); 
				onColor: Color transparent offColor: Color white.
			aRow addMorphBack: aButton.
			aButton setBalloonText: triplet third].
		
	Preferences alternativeWindowLook ifTrue:[
		aRow color: Color transparent.
		aRow submorphsDo:[:m| m borderWidth: 2; borderColor: #raised].
	].

	^ aRow