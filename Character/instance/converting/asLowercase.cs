asLowercase
	"If the receiver is uppercase, answer its matching lowercase Character."
	
	(8r101 <= value and: [value <= 8r132])  "self isUppercase"
		ifTrue: [^ Character value: value + 8r40]
		ifFalse: [^ self]