triggerOpeningScripts
	"If the receiver has any scripts set to run on opening, run them now"
	| aPlayer |
	(aPlayer _ self player) ifNotNil:
		[aPlayer runAllOpeningScripts]