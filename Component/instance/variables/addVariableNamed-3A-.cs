addVariableNamed: varName 
	"Adjust name if necessary and add it"

	| otherNames i partName |
	otherNames := self class allInstVarNames.
	i := nil.
	
	[partName := i isNil 
		ifTrue: [varName]
		ifFalse: [varName , i printString].
	otherNames includes: partName] 
			whileTrue: [i := i isNil ifTrue: [1] ifFalse: [i + 1]].
	self class addInstVarName: partName.

	"Now compile read method and write-with-change method"
	self class 
		compile: (String streamContents: 
					[:s | 
					s
						nextPutAll: partName;
						cr;
						tab;
						nextPutAll: '^' , partName])
		classified: 'view access'
		notifying: nil.
	self class 
		compile: (String streamContents: 
					[:s | 
					s
						nextPutAll: partName , 'Set: newValue';
						cr;
						tab;
						nextPutAll: partName , ' _ newValue.';
						cr;
						tab;
						nextPutAll: 'self changed: #' , partName , '.';
						cr;
						tab;
						nextPutAll: '^ true'	"for components that expect a boolean for accept"])
		classified: 'view access'
		notifying: nil.
	^Array with: partName asSymbol with: (partName , 'Set:') asSymbol