asUnsignedInteger 
	"Returns the first integer it can find or nil."

	| start stream |
	start := self findFirst: [:char | char isDigit].
	start isZero ifTrue: [^nil].
	stream := (ReadStream on: self) position: start - 1.
	^Integer readFrom: stream