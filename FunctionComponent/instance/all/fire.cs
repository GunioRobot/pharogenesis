fire
	| arguments newValue |
	outputSelector ifNil: [^ outputValue _ nil].
	functionSelector ifNil: [^ outputValue _ nil].
	arguments _ inputSelectors collect:
		[:s | s ifNil: [nil] ifNotNil: [model perform: s]].
	newValue _ (arguments findFirst: [:a | a==nil]) = 0
		ifTrue: [model perform: functionSelector withArguments: arguments]
		ifFalse: [nil].
	newValue = outputValue ifFalse:
		[model perform: outputSelector with: newValue.
		outputValue _ newValue]