/ aNumber
	"Refer to the comment in Number / "
	| quoRem |
	aNumber isInteger
		ifTrue: [quoRem _ self digitDiv: aNumber 
								neg: self negative ~~ aNumber negative.
				(quoRem at: 2) = 0
					ifTrue: [^(quoRem at: 1) normalize]
					ifFalse: [^(Fraction numerator: self denominator: aNumber) reduced]]
		ifFalse: [^ (aNumber adaptInteger: self) / aNumber adaptToInteger]