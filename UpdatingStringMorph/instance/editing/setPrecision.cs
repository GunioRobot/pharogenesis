setPrecision
	| aList aMenu reply |
	aList _ #('0' '1' '2' '3' '4' '5').
	aMenu _ SelectionMenu labels: aList selections: aList.
	reply _ aMenu startUpWithCaption: 'How many decimal places?'.
	reply ifNotNil:
		[self floatPrecision:
			(#(1 0.1 0.01 0.001 0.0001 0.00001 0.000001) at: (aList indexOf: reply))]