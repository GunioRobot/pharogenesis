customButtonRow
	"Answer a button pane affording the user one-touch access to certain functions; the pane is given the formal name 'customButtonPane' by which it can be retrieved by code wishing to send messages to widgets residing on the pane"

	| aRow aButton aLabel |
	aRow _ AlignmentMorph newRow beSticky.
	aRow setNameTo: 'customButtonPane'.
	aRow clipSubmorphs: true.
	aButton _ SimpleButtonMorph new target: self.
	aButton color: Color lightRed; borderWidth: 1; borderColor: Color red darker.
	aRow addTransparentSpacerOfSize: (5@0).
	self customButtonSpecs do:
		[:tuple |
			aButton _ PluggableButtonMorph
				on: self
				getState: nil
				action: tuple second.
			aButton
				hResizing: #spaceFill;
				vResizing: #spaceFill;
				useRoundedCorners;
				onColor: Color transparent offColor: Color transparent.
			(#(proceed restart send doStep stepIntoBlock fullStack where) includes: tuple second)
				ifTrue:
					[aButton askBeforeChanging: true].

			aLabel _ Preferences abbreviatedBrowserButtons 
				ifTrue: [self abbreviatedWordingFor: tuple second]
				ifFalse: [nil].
			aButton label: (aLabel ifNil: [tuple first asString]).

			tuple size > 2 ifTrue: [aButton setBalloonText: tuple third].
			Preferences alternativeWindowLook 
				ifTrue:[aButton borderWidth: 2; borderColor: #raised].
			aRow addMorphBack: aButton.
			aRow addTransparentSpacerOfSize: (3 @ 0)].
	^ aRow