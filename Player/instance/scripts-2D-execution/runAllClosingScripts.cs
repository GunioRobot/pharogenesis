runAllClosingScripts
	"Run all the receiver's scripts marked as #closing.  Return a boolean indicating whether any such scripts were encountered and run"

	| any |
	any _ false.
	self instantiatedUserScriptsDo:
		[:aScriptInstantiation | aScriptInstantiation runIfClosing ifTrue: [any _ true]].
	^ any