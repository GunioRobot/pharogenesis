next: n

		| string peekChar |
		string _ super next: n.
		string size = 0 ifTrue: [ ^string ].
		self isBinary ifTrue: [ ^string ].

		"if we just read a CR, and the next character is an LF, then skip the LF"
		( string last = Character cr ) ifTrue: [
			peekChar _ super next.		"super peek doesn't work because it relies on #next"
			peekChar ~= Character lf ifTrue: [
				super position: (super position - 1) ]. ].
 
		string _ string withSqueakLineEndings.

		string size = n ifTrue: [ ^string ].

		"string shrunk due to embedded crlfs; make up the difference"
		^string, (self next: n - string size)