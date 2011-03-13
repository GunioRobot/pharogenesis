actualClass
	"Answer the class represented in the receiver."

	^super actualClass ifNil: [Smalltalk classNamed: self item]