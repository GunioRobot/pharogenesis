testReplaceFromToWithStartingAt
	| result  repStart collection replacementCollection firstIndex secondIndex |
	collection := self nonEmpty .
	result := collection copy.
	replacementCollection := self replacementCollectionSameSize .
	firstIndex := self firstIndex .
	secondIndex := self secondIndex .
	repStart := replacementCollection  size - ( secondIndex  - firstIndex   + 1 ) + 1.
	result replaceFrom: firstIndex  to: secondIndex with: replacementCollection  startingAt: repStart   .
	
	"verify content of 'result' : "
	"first part of 'result'' : '" 
	
	1 to: ( firstIndex  - 1 ) do: [ :i | self assert: ( collection  at:i ) = ( result at: i ) ].
	
	" middle part containing replacementCollection : "
	
	( firstIndex ) to: ( replacementCollection   size - repStart +1 ) do: 
		[:i|
		self assert: (result at: i)=( replacementCollection   at: ( repStart  + ( i  -firstIndex  ) ) ) ].
	
	" end part :"
	( firstIndex  + replacementCollection   size ) to: ( result size ) do:
		[ :i |
		self assert: ( result at: i ) = ( collection  at: ( secondIndex  + 1 - ( firstIndex  + replacementCollection   size ) + i ) ) ].