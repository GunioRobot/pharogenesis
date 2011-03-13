allMethodsWithSourceString: aString matchCase: caseSensitive
	"Answer a SortedCollection of all the methods that contain, in source code, aString as a substring.  Search the class comments also"

	| list count adder |
	list := Set new.
	adder := [ :mrClass :mrSel | list add: ( MethodReference new
											setStandardClass: mrClass
											methodSymbol: mrSel)].
	'Searching all source code...'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: Smalltalk classNames size
		during: [:bar |
			count := 0.
			SystemNavigation default allBehaviorsDo: [:each |
				bar value: (count := count + 1).
					each selectorsDo: [:sel | 
						((each sourceCodeAt: sel) findString: aString 
							startingAt: 1 caseSensitive: caseSensitive) > 0 ifTrue: [
								sel isDoIt ifFalse: [adder value: each value: sel]]].
					(each organization classComment asString findString: aString 
							startingAt: 1 caseSensitive: caseSensitive) > 0 ifTrue: [
								adder value: each value: #Comment]	]].
			^ list asSortedCollection