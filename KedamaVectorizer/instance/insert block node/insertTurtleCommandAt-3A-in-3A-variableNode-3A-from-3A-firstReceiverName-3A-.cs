insertTurtleCommandAt: index in: statements variableNode: varNode from: encoder firstReceiverName: origName

	| messageNode blockNode newMessageNode selector |
	messageNode _ statements at: index.
	(attributes getAttribute: #requireVector of: messageNode) ifFalse: [^ self].
	blockNode _ BlockNode new arguments: (Array with: varNode) statements: (Array with: messageNode) returns: false from: encoder.
	selector _ (attributes getAttribute: #dieMessage of: messageNode) ifNotNil: [#doDieCommand:].
	selector ifNil: [
		selector _ (attributes getAttribute: #constant of: messageNode) ifTrue: [#doCommand:] ifFalse: [#doSequentialCommand:].
	].
		
	newMessageNode _ MessageNode new
				receiver: (encoder encodeVariable: origName)
				selector: selector
				arguments: (Array with: blockNode)
				precedence: 3
				from: encoder
				sourceRange: nil.

	statements at: index put: newMessageNode.
