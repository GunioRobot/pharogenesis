quo: aNumber 
	"Refer to the comment in Number quo: "
	| ng quo |
	aNumber isInteger
		ifTrue: 
			[ng _ self negative == aNumber negative == false.
			quo _ (self digitDiv: aNumber neg: ng) at: 1.
			^ quo normalize]
		ifFalse: [^ (aNumber adaptInteger: self) quo: aNumber adaptToInteger]