runAllOpeningScripts
	"Run all the receiver's scripts marked as #opening.  Return a boolean indicating whether any such scripts were encountered and run"

	| any |
	any _ false.
	self instantiatedUserScriptsDo:
		[:aScriptInstantiation | aScriptInstantiation runIfOpening ifTrue: [any _ true]].
	^ any