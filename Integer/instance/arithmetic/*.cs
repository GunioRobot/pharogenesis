* aNumber
	"Refer to the comment in Number * " 
	aNumber isInteger
		ifTrue: [^ self digitMultiply: aNumber 
					neg: self negative ~~ aNumber negative]
		ifFalse: [^self retry: #* coercing: aNumber]