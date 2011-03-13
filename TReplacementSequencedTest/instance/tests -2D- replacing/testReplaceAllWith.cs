testReplaceAllWith
	| result  collection oldElement newElement |
	collection := self nonEmpty .
	result := collection  copy.
	oldElement := self elementInForReplacement .
	newElement := self newElement .
	result replaceAll: oldElement  with: newElement  .
	
	1 to: collection  size do:
		[:
		each |
		( collection at: each ) = oldElement 
			ifTrue: [ self assert: ( result at: each ) = newElement ].
		].