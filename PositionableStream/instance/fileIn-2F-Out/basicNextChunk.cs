basicNextChunk
	"Answer the contents of the receiver, up to the next terminator character. Doubled terminators indicate an embedded terminator character."
	| terminator out ch |
	terminator _ $!.
	out _ WriteStream on: (String new: 1000).
	self skipSeparators.
	[(ch _ self next) == nil] whileFalse: [
		(ch == terminator) ifTrue: [
			self peek == terminator ifTrue: [
				self next.  "skip doubled terminator"
			] ifFalse: [
				^ out contents  "terminator is not doubled; we're done!"
			].
		].
		out nextPut: ch.
	].
	^ out contents