addVariableNamed: varName
	| otherNames i partName |
	"Adjust name if necessary and add it"
	otherNames _ self class allInstVarNames.
	i _ nil.
	[i == nil ifTrue: [partName _ varName] ifFalse: [partName _ varName, i printString].
	otherNames includes: partName]
		whileTrue: [i == nil ifTrue: [i _ 1] ifFalse: [i _ i + 1]].
	self class addInstVarName: partName.

	"Now compile read method and write-with-change method"
	self class compile: (String streamContents:
			[:s | s nextPutAll: partName; cr;
			tab; nextPutAll: '^', partName])
		classified: 'view access'
		notifying: nil.
	self class compile: (String streamContents:
			[:s | s nextPutAll: partName, 'Set: newValue'; cr;
				tab; nextPutAll: partName, ' _ newValue.'; cr;
				tab; nextPutAll: 'self changed: #', partName])
		classified: 'view access'
		notifying: nil.

	^ Array with: partName asSymbol with: (partName , 'Set:') asSymbol