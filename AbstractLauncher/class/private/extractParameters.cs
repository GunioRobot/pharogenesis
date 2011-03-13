extractParameters
	| pName value index globals |
	globals := Dictionary new.
	index := 3. "Muss bei 3 starten, da 2 documentName ist"
	[pName := Smalltalk getSystemAttribute: index.
	pName isEmptyOrNil] whileFalse:[
		index := index + 1.
		value := Smalltalk getSystemAttribute: index.
		value ifNil: [value _ ''].
 		globals at: pName asUppercase put: value.
		index := index + 1].
	^globals