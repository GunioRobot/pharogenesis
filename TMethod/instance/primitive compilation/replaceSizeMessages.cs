replaceSizeMessages
	"Replace sends of the message 'size' with calls to sizeOfSTArrayFromCPrimitive."

	| argExpr |
	parseTree nodesDo: [:n |
		(n isSend and: [n selector = #size]) ifTrue: [
			argExpr _ TSendNode new
				setSelector: #+
				receiver: n receiver
				arguments: (Array with: (TConstantNode new setValue: 1)).
			n
				setSelector: #sizeOfSTArrayFromCPrimitive:
				receiver: (TVariableNode new setName: 'self')
				arguments: (Array with: argExpr)]].
