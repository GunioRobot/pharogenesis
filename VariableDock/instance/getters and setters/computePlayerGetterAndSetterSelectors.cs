computePlayerGetterAndSetterSelectors
	"Compute and remember the getter and setter selectors for obtaining and setting values from the player instance"

	playerGetSelector _ Utilities getterSelectorFor: variableName.
	playerPutSelector _ Utilities setterSelectorFor: variableName