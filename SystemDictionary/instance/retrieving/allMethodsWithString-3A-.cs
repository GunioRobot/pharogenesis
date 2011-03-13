allMethodsWithString: aString 
	"Answer a SortedCollection of all the methods that contain, in a string literal, aString as a substring.  2/1/96 sw.  The search is case-sensitive, and does not dive into complex literals, confining itself to string constants.
	5/2/96 sw: fixed so that duplicate occurrences of aString in the same method don't result in duplicated entries in the browser"

	| aStringSize list lits |

	aStringSize _ aString size.
	list _ Set new.

	Cursor wait showWhile: [self allBehaviorsDo: 
		[:class | class selectorsDo:
			[:sel | sel ~~ #DoIt ifTrue:
				[lits _ (class compiledMethodAt: sel) literals.
				lits do:
					[:aLiteral | ((aLiteral isMemberOf: String) and:
						[aLiteral size >= aStringSize])
							ifTrue:
								[(aLiteral findString: aString startingAt: 1)  > 0 ifTrue:
									[list add: class name , ' ' , sel]]]]]]].
	^ list asSortedCollection