buttonRowForPreDebugWindow: aDebugWindow
	| aRow aButton quads |
	aRow := AlignmentMorph newRow hResizing: #spaceFill; vResizing: #spaceFill.
	aRow layoutInset: 1; cellInset: 1.
	aRow beSticky.
	aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer.
	quads := OrderedCollection withAll: self preDebugButtonQuads.
	(self interruptedContext selector == #doesNotUnderstand:) ifTrue: [
		quads add: { 'Create'. #createMethod. #magenta. 'create the missing method' }
	].
	quads do:
			[:quad |
				aButton := SimpleButtonMorph new target: aDebugWindow.
				aButton color: Color white; borderWidth: 1.
				aButton actionSelector: quad second.
				aButton label: quad first.
				aButton submorphs first color: (Color colorFrom: quad third).
				aButton setBalloonText: quad fourth.
				aButton borderStyle: BorderStyle thinGray.
				aButton useSquareCorners.
				aRow addMorphBack: aButton.
				aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer].
	^ aRow