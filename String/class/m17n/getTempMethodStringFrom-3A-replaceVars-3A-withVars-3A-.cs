getTempMethodStringFrom: original replaceVars: oldClassVarNames withVars: newClassVarNames

	| str start index stream |
	str _ original.
	oldClassVarNames with: newClassVarNames do: [:var :newVar |
		start _ 1.
		[(index _ self getDelimited: var from: start in: str) > 0] whileTrue: [
			stream _ WriteStream on: (String new: original size + 1).
			stream nextPutAll: (str copyFrom: 1 to: index - 1).
			stream nextPutAll: newVar.
			stream nextPutAll: (str copyFrom: index + var size to: str size).
			str _ stream contents.
			start _ index + var size + 1.
		].
	].
	^ str.
