allMethodsWithSourceString: aString matchCase: caseSensitive
	"Answer a SortedCollection of all the methods that contain, in source code, aString as a substring.  The search is case-insensitive."
	| list classCount |
	list _ Set new.
'Searching all source code...'
displayProgressAt: Sensor cursorPoint
from: 0 to: Smalltalk classNames size
during:
	[:bar | classCount _ 0.
	Smalltalk allClassesDo:
		[:class | bar value: (classCount _ classCount + 1).
		(Array with: class with: class class) do:
			[:cl | cl selectorsDo:
				[:sel | 
				((cl sourceCodeAt: sel) findString: aString startingAt: 1 caseSensitive: caseSensitive) > 0
					ifTrue:
					[sel == #DoIt ifFalse: [list add: cl name , ' ' , sel]]]]]].
	^ list asSortedCollection