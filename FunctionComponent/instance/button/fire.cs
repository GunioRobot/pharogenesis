fire
	| arguments newValue |
	outputSelector ifNil: [^outputValue := nil].
	functionSelector ifNil: [^outputValue := nil].
	arguments := inputSelectors 
				collect: [:s | s ifNil: [nil] ifNotNil: [model perform: s]].
	newValue := (arguments findFirst: [:a | a isNil]) = 0 
				ifTrue: [model perform: functionSelector withArguments: arguments]
				ifFalse: [nil].
	newValue = outputValue 
		ifFalse: 
			[model perform: outputSelector with: newValue.
			outputValue := newValue]