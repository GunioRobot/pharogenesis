scriptSelectorToTriggerFor: aButtonMorph
	"Answer a new selector which will bear the code for aButtonMorph in the receiver"

	| buttonName selectorName |
	buttonName _ aButtonMorph externalName.
	selectorName _ self assuredPlayer acceptableScriptNameFrom: buttonName  forScriptCurrentlyNamed: nil.

	buttonName ~= selectorName ifTrue:
		[aButtonMorph setNameTo: selectorName].
	^ selectorName