addClassVarName: aString 
	"Add the argument, aString, as a class variable of the receiver.
	Signal an error if the first character of aString is not capitalized,
	or if it is already a variable named in the class."
	| symbol index |
	aString first isLowercase
		ifTrue: [^self error: aString, ' class variable name should be capitalized; proceed to include anyway.'].
	symbol _ aString asSymbol.
	self withAllSubclasses do: 
		[:subclass | 
		subclass scopeHas: symbol
			ifTrue: [:temp | 
					^ self error: aString 
						, ' is already used as a variable name in class ' 
						, subclass name]].
	classPool == nil ifTrue: [classPool _ Dictionary new].
	(classPool includesKey: symbol) ifFalse: 
		["Pick up any refs in Undeclared"
		classPool declare: symbol from: Undeclared.
		Smalltalk changes changeClass: self]