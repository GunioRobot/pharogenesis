readNumberBase: base
	"Read a hex number from stream until encountering $; "

	| value digit |
	value _ 0.
	digit _ DigitTable at: self peek asciiValue.
	digit < 0
		ifTrue: [self error: 'At least one digit expected here'].
	self next.
	value _ digit.
	[digit _ DigitTable at: self peek asciiValue.
	digit < 0
		ifTrue: [^value]
		ifFalse: [
			self next.
			value _ value * base + digit]
		] repeat.
	^ value