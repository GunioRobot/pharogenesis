asSignedInteger 
	"Returns the first signed integer it can find or nil."

	| start stream |
	start := self findFirst: [:char | char isDigit].
	start isZero ifTrue: [^nil].
	stream := (ReadStream on: self) position: start.
	stream back = $- ifTrue: [stream back].
	^Integer readFrom: stream