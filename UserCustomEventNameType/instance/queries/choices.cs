choices
	"Answer an alphabetized list of known user custom event selectors"

	| choices |
	choices _ ScriptingSystem userCustomEventNames.
	^choices isEmpty ifTrue: [ #('no event') ] ifFalse: [ choices ]