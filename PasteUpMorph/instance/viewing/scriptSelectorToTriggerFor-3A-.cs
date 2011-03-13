scriptSelectorToTriggerFor: aButtonMorph
	"Answer a new selector which will bear the code for aButtonMorph in the receiver"

	| buttonName selectorName |
	buttonName _ aButtonMorph externalName.
	selectorName _ ScriptingSystem acceptableScriptNameFrom: buttonName  forScriptCurrentlyNamed:  nil asScriptNameIn: self assuredPlayer world: self world.

	buttonName ~= selectorName ifTrue:
		[aButtonMorph setNameTo: selectorName].
	^ selectorName