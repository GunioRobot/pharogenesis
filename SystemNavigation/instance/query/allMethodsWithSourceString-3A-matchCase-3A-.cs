allMethodsWithSourceString: aString matchCase: caseSensitive
	"Answer a SortedCollection of all the methods that contain, in source code, aString as a substring.  Search the class comments also"

	| list classCount adder |
	list _ Set new.
	adder _ [ :mrClass :mrSel | list add: ( MethodReference new
											setStandardClass: mrClass
											methodSymbol: mrSel)].
'Searching all source code...'
displayProgressAt: Sensor cursorPoint
from: 0 to: Smalltalk classNames size
during:
	[:bar | classCount _ 0.
	Smalltalk allClassesDo:
		[:class | bar value: (classCount _ classCount + 1).
		(Array with: class with: class class) do:
			[:cl | 
				cl selectorsDo: [:sel | 
					((cl sourceCodeAt: sel) findString: aString 
						startingAt: 1 caseSensitive: caseSensitive) > 0 ifTrue: [
							sel == #DoIt ifFalse: [adder value: cl value: sel]]].
				(cl organization classComment asString findString: aString 
						startingAt: 1 caseSensitive: caseSensitive) > 0 ifTrue: [
							adder value: cl value: #Comment].
			]]].
	^ list asSortedCollection