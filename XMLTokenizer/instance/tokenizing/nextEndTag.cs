nextEndTag
	| string |
	"Skip /"
	self next.
	self skipSeparators.
	string _ self nextTrimmedBlanksUpTo: $>.
	"string _ (self nextUpTo: $>) withBlanksTrimmed."
	self handleEndTag: string