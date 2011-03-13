asUppercase
	"If the receiver is lowercase, answer its matching uppercase Character."
	
	(8r141 <= value and: [value <= 8r172])  "self isLowercase"
		ifTrue: [^ Character value: value - 8r40]
		ifFalse: [^ self]