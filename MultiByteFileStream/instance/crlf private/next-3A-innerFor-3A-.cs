next: n innerFor: aString

	| peekChar state |
	"if we just read a CR, and the next character is an LF, then skip the LF"
	aString size = 0 ifTrue: [^ aString].
	(aString last = Character cr) ifTrue: [
		state _ converter saveStateOf: self.
		peekChar _ self bareNext.		"super peek doesn't work because it relies on #next"
		(peekChar notNil and: [peekChar ~= Character lf]) ifTrue: [
			converter restoreStateOf: self with: state.
		].
	].
 
	^ aString withSqueakLineEndings.
