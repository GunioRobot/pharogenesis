+ aNumber
	"Refer to the comment in Number + "
	(aNumber isInteger)
		ifTrue: [self negative == aNumber negative
					ifTrue: [^(self digitAdd: aNumber) normalize]
					ifFalse: [^self digitSubtract: aNumber]]
		ifFalse: [^self retry: #+ coercing: aNumber]