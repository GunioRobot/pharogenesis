- aNumber
	"Refer to the comment in Number - "
	aNumber isInteger
		ifTrue: [self negative == aNumber negative
					ifTrue: [^ self digitSubtract: aNumber]
					ifFalse: [^ (self digitAdd: aNumber) normalize]]
		ifFalse: [^ (aNumber adaptInteger: self) - aNumber adaptToInteger]