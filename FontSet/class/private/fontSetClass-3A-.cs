fontSetClass: aString
	| className fontSet |
	className _ (self name , (aString select: [:c | c isAlphaNumeric]) capitalized) asSymbol.
	fontSet _ Smalltalk
		at: className
		ifAbsentPut: [self
			subclass: className
			instanceVariableNames: ''
			classVariableNames: ''
			poolDictionaries: ''
			category: self fontCategory].
	(fontSet inheritsFrom: self) ifFalse: [^ self error: 'The name ' , className , ' is already in use'].
	^ fontSet