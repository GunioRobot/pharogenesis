optionalButtonRow
	| aRow aButton |
	aRow _ AlignmentMorph newRow beSticky.
	aRow setProperty: #clipToOwnerWidth toValue: true.
	aButton _ SimpleButtonMorph new target: self.
	aButton color: Color lightRed; borderWidth: 1; borderColor: Color red darker.
	aRow addTransparentSpacerOfSize: (5@0).
	self optionalButtonPairs do:
		[:pair |
				aButton _ PluggableButtonMorph
					on: self
					getState: nil
					action: pair second.
				aButton useRoundedCorners;
					label: pair first asString;
					askBeforeChanging: true;
					onColor: Color transparent offColor: Color transparent.
				aRow addMorphBack: aButton.
				aRow addTransparentSpacerOfSize: (3 @ 0)].
	^ aRow