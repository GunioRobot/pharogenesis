backChunk
	"Answer the contents of the receiver back to the previous terminator character.  Doubled terminators indicate an embedded terminator character."

	| terminator out ch |
	terminator := $!.
	out := WriteStream on: (String new: 1000).
	[(ch := self oldBack) == nil] whileFalse: 
			[ch == terminator 
				ifTrue: 
					[self peekBack == terminator 
						ifTrue: [self oldBack	"skip doubled terminator"]
						ifFalse: [^ out contents reversed]].
			out nextPut: ch].
	^ out contents reversed