userScriptForPlayer: aPlayer selector: aSelector
	"Answer the user script for the player (one copy for all instances of the uniclass) and selector"

	|  entry existingEntry |
	scripts ifNil: [scripts _ IdentityDictionary new].
	existingEntry _ scripts at: aSelector ifAbsent: [nil].
	(existingEntry isKindOf: UniclassScript)
		ifFalse:
			[entry _ UniclassScript new playerClass: aPlayer class selector: aSelector.
			scripts at: aSelector put: entry.
			existingEntry ifNotNil: "means it is a grandfathered UserScript that needs conversion"
				[entry convertFromUserScript: existingEntry]]
		ifTrue:
			[entry _ existingEntry].
	^ entry