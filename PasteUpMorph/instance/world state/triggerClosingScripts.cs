triggerClosingScripts
	"If the receiver has any scripts set to run on closing, run them now"
	| aPlayer |
	(aPlayer _ self player) ifNotNil:
		[aPlayer runAllClosingScripts]