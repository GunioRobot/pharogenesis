nextDelimited: terminator

	| out ch save |
	out _ WriteStream on: (String new: 1000).
	self atEnd ifTrue: [^ ''].
	save _ converter saveStateOf: self.

	self next = terminator ifFalse: [
		"absorb initial terminator"
		converter restoreStateOf: self with: save.
	].
	[(ch _ self next) == nil] whileFalse: [
		(ch = terminator) ifTrue: [
			self peek = terminator ifTrue: [
				self next.  "skip doubled terminator"
			] ifFalse: [
				^ out contents  "terminator is not doubled; we're done!"
			].
		].
		out nextPut: ch.
	].
	^ out contents.
