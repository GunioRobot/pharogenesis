backChunk
	"Answer the contents of the receiver back to the previous terminator character.  Doubled terminators indicate an embedded terminator character."
	| terminator out ch |
	terminator _ $!.
	out _ WriteStream on: (String new: 1000).
	[(ch _ self back) == nil] whileFalse: [
		(ch == terminator) ifTrue: [
			self peekBack == terminator ifTrue: [
				self back.  "skip doubled terminator"
			] ifFalse: [
				^ out contents reversed  "we're done!"
			].
		].
		out nextPut: ch.
	].
	^ out contents reversed