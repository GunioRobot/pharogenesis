buttonDisabledFillStyleFor: aButton
	"Return the disabled button fillStyle for the given color."
	
	^aButton colorToUse lighter whiter alpha: 0.6