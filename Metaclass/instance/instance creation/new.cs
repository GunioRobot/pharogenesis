new
	"The receiver can only have one instance. Create it or complain that
	one already exists."

	thisClass class ~~ self
		ifTrue: [^thisClass _ self basicNew]
		ifFalse: [self error: 'A Metaclass should only have one instance!']