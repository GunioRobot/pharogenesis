blockExpression
	"[ ({:var} |) (| {temps} |) (statements) ] => BlockNode."

	| variableNodes temporaryBlockVariables |
	variableNodes _ OrderedCollection new.

	"Gather parameters."
	(self matchToken: 'With') ifTrue:
		[[self match: #period]
			whileFalse: [variableNodes addLast: (encoder autoBind: self argumentName)]].

	temporaryBlockVariables _ self temporaryBlockVariables.
	self statements: variableNodes innerBlock: true.
	parseNode temporaries: temporaryBlockVariables.

	(self match: #rightBracket) ifFalse: [^ self expected: 'Period or right bracket'].

	"The scope of the parameters and temporary block variables is no longer active."
	temporaryBlockVariables do: [:variable | variable scope: -1].
	variableNodes do: [:variable | variable scope: -1]