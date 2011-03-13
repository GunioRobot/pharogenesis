testReplaceFromToWith
	| result  collection replacementCollection firstIndex secondIndex |
	collection := self nonEmpty .
	replacementCollection := self replacementCollectionSameSize .
	firstIndex := self firstIndex .
	secondIndex := self secondIndex .
	result := collection  copy.
	result replaceFrom: firstIndex  to: secondIndex  with: replacementCollection   .
	
	"verify content of 'result' : "
	"first part of 'result'' : '"
	
	1 to: ( firstIndex - 1 ) do: [ :i | self assert: (collection  at:i ) = ( result at: i ) ].
	
	" middle part containing replacementCollection : "
	
	( firstIndex ) to: ( firstIndex  + replacementCollection size - 1 ) do: 
		[ :i |
		self assert: ( result at: i ) = ( replacementCollection  at: ( i - firstIndex  +1 ) ) 
		].
	
	" end part :"
	( firstIndex  + replacementCollection   size) to: (result size) do:
		[:i|
		self assert: ( result at: i ) = ( collection at: ( secondIndex  + 1 - ( firstIndex + replacementCollection size ) + i ) ) ].
	
	