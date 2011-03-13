derivativeFont: aTTCFont at: index

	| newDeriv |
	aTTCFont ifNil: [derivatives _ nil. ^ self].
	derivatives ifNil: [derivatives _ Array new: 32].
	derivatives size < 32 ifTrue: [
		newDeriv _ Array new: 32.
		newDeriv replaceFrom: 1 to: derivatives size with: derivatives.
		derivatives _ newDeriv.
	].
	derivatives at: index put: aTTCFont.
