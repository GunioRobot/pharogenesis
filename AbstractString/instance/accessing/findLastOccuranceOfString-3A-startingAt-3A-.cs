findLastOccuranceOfString: subString startingAt: start 
	"Answer the index of the last occurance of subString within the receiver, starting at start. If 
	the receiver does not contain subString, answer 0."

	| last now |
	last _ self findSubstring: subString in: self startingAt: start matchTable: CaseSensitiveOrder.
	last = 0 ifTrue: [^ 0].
	[last > 0] whileTrue: [
		now _ last.
		last _ self findSubstring: subString in: self startingAt: last + subString size matchTable: CaseSensitiveOrder.
	].

	^ now.
