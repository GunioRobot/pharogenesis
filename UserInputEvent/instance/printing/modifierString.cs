modifierString
	"Return a string identifying the currently pressed modifiers"
	| string |
	string _ ''.
	self commandKeyPressed ifTrue:[string _ string,'CMD '].
	self shiftPressed ifTrue:[string _ string,'SHIFT '].
	self controlKeyPressed ifTrue:[string _ string,'CTRL '].
	^string