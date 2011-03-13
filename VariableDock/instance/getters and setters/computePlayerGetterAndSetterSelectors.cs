computePlayerGetterAndSetterSelectors
	"Compute and remember the getter and setter selectors for obtaining and setting values from the player instance"

	playerGetSelector := Utilities getterSelectorFor: variableName.
	playerPutSelector := Utilities setterSelectorFor: variableName