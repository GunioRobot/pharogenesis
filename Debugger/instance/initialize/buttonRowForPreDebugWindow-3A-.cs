buttonRowForPreDebugWindow: aDebugWindow
	| aRow aButton |
	aRow _ AlignmentMorph newRow hResizing: #spaceFill.
	aRow beSticky.
	aButton _ SimpleButtonMorph new target: aDebugWindow.
	aButton color: Color transparent; borderWidth: 1.
	aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer.
	self preDebugButtonQuads do:
			[:quad |
				aButton _ aButton fullCopy.
				aButton actionSelector: quad second.
				aButton label: quad first.
				aButton submorphs first color: (Color colorFrom: quad third).
				aButton setBalloonText: quad fourth.
				aRow addMorphBack: aButton.
				aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer].
	^ aRow