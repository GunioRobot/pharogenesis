generateAsOop: aNode on: aStream indent: anInteger

	| cName class |
	cName _ aNode args first nameOrValue.
	class _ Smalltalk 
		at: (cName asSymbol) 
		ifAbsent: [nil].
	(class isNil not and: [class isBehavior]) ifFalse: 
		[^self error: 'first arg must identify class'].
	class ccg: self generateCoerceToOopFrom: aNode receiver on: aStream