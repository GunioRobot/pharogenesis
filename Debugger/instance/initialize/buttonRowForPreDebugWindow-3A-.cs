buttonRowForPreDebugWindow: aDebugWindow
	| aRow aButton quads |
	aRow _ AlignmentMorph newRow hResizing: #spaceFill.
	aRow beSticky.
	aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer.
	quads _ OrderedCollection withAll: self preDebugButtonQuads.
	(self interruptedContext selector == #doesNotUnderstand:) ifTrue: [
		quads add: { 'Create'. #createMethod. #magenta. 'create the missing method' }
	].
	quads do:
			[:quad |
				aButton _ SimpleButtonMorph new target: aDebugWindow.
				aButton color: Color transparent; borderWidth: 1.
				aButton actionSelector: quad second.
				aButton label: quad first.
				aButton submorphs first color: (Color colorFrom: quad third).
				aButton setBalloonText: quad fourth.
				Preferences alternativeWindowLook 
					ifTrue:[aButton borderWidth: 2; borderColor: #raised].
				aRow addMorphBack: aButton.
				aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer].
	^ aRow