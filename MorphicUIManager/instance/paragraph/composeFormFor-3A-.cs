composeFormFor: aDisplayText
	
	| canvas tmpText |
	
	tmpText := TextMorph new contentsAsIs: aDisplayText text deepCopy.	
	aDisplayText foregroundColor ifNotNil: [tmpText text addAttribute: (TextColor color: aDisplayText foregroundColor)].
	aDisplayText backgroundColor ifNotNil: [tmpText backgroundColor: aDisplayText backgroundColor].
	tmpText setTextStyle: aDisplayText textStyle.	
	canvas := FormCanvas on: (Form extent: tmpText extent depth: 32).
	tmpText drawOn: canvas.
	aDisplayText form: canvas form.
					
	^ canvas form		