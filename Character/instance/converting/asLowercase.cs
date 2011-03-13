asLowercase
	"If the receiver is uppercase, answer its matching lowercase Character."
	
	self isUppercase ifTrue: [^Character value: value+8r40]