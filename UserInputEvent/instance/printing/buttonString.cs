buttonString
	"Return a string identifying the currently pressed buttons"
	| string |
	string _ ''.
	self redButtonPressed ifTrue:[string _ string,'red '].
	self yellowButtonPressed ifTrue:[string _ string,'yellow '].
	self blueButtonPressed ifTrue:[string _ string,'blue '].
	^string