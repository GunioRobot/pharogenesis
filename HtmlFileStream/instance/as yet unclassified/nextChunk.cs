nextChunk
	"Answer the contents of the receiver, up to the next terminator character (!).  Imbedded terminators are doubled.  Undo and strip out all Html stuff in the stream and convert the characters back.  4/12/96 tk"
	| out char did rest |
	self skipSeparators.	"Absorb <...><...> also"
	out _ WriteStream on: (String new: 500).
	[self atEnd] whileFalse: [
		self peek = $< ifTrue: [self unCommand].	"Absorb <...><...>"
		(char _ self next) = $&
			ifTrue: [
				rest _ self upTo: $;.
				did _ out position.
				rest = 'lt' ifTrue: [out nextPut: $<].
				rest = 'gt' ifTrue: [out nextPut: $>].
				rest = 'amp' ifTrue: [out nextPut: $&].
				did = out position ifTrue: [
					self error: 'new HTML char encoding'.
					"Please add it to this code"]]
			ifFalse: [char = $!	"terminator"
				ifTrue: [
					self peek = $! ifFalse: [^ out contents].
					out nextPut: self next]	"pass on one $!"
				ifFalse: [out nextPut: char]]
		].
	^ out contents