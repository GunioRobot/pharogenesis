transparentFromUser: aForm
	"Displays the Form and asks the user to click on the color that should be transparent.  Creates a MaskedForm.  6/21/96 tk"

	| save pt pixVal c |
	save _ Form fromDisplay: (0@0 extent: aForm extent).
	aForm displayAt: 0@0.
	[Sensor anyButtonPressed] whileFalse.
	pt _ Sensor cursorPoint.
	pt < aForm extent
		ifTrue: [pixVal _ aForm pixelValueAt: pt]
		ifFalse: [pixVal _ Display pixelValueAt: pt.
			Display depth ~= aForm depth ifTrue: [
				c _ Color colorFromPixelValue: pixVal 
					depth: Display depth.
				pixVal _ c pixelValueForDepth: aForm depth]].
	save displayAt: 0@0.
	Sensor waitNoButton.
	
	^ self new setForm: aForm transparentPixelValue: pixVal

"	(MaskedForm transparentFromUser: (Form fromUser)) followCursor
"