optionalButtonRow
	"Answer a button pane affording the user one-touch access to certain functions; the pane is given the formal name 'buttonPane' by which it can be retrieved by code wishing to send messages to widgets residing on the pane"

	| aRow aButton |
	aRow _ AlignmentMorph newRow beSticky.
	aRow setNameTo: 'buttonPane'.
	aRow clipSubmorphs: true.
	aButton _ SimpleButtonMorph new target: self.
	aButton color: Color lightRed; borderWidth: 1; borderColor: Color red darker.
	aRow addTransparentSpacerOfSize: (5@0).
	self optionalButtonPairs do:
		[:pair |
				aButton _ PluggableButtonMorph
					on: self
					getState: nil
					action: pair second.
				aButton
					hResizing: #spaceFill;
					vResizing: #spaceFill;
					useRoundedCorners;
					label: pair first asString;
					askBeforeChanging: true;
					onColor: Color transparent offColor: Color transparent.
				aRow addMorphBack: aButton.
				aRow addTransparentSpacerOfSize: (3 @ 0)].
	^ aRow