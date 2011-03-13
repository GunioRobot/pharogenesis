retry: arith coercing: argument 
	"Arithmetic represented by the message, arith, could not be performed 
	between the receiver and the argument because of differences in
	representation. Coerce either the receiver or the argument to a more
	general representation, and try again."

	(argument isKindOf: Number)
		ifTrue:
			[self generality < argument generality
				ifTrue: [^ (argument coerce: self) perform: arith with: argument]
				ifFalse: [^ self perform: arith with: (self coerce: argument)]]
		ifFalse: [^ argument perform: arith with: self]