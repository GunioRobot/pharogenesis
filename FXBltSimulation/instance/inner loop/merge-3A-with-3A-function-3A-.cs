merge: sourceWord with: destinationWord function: mergeFn
	^self perform: (self cCoerce: mergeFn to: 'int (*) (int, int)')
		with: sourceWord
		with: destinationWord