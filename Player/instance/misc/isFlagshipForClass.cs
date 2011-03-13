isFlagshipForClass
	"Answer whether the receiver is the so-called flagshipInstance for the uniclass.  A dying thing"

	self flag: #noteToTed.
	"SyntaxMorph has the only remaining call to this; once that's been converted over, this method, and #flagshipInstance as well, can be remobved"
	^ self class flagshipInstance == self