blockExpression
	"[ ({:var} |) (| {temps} |) (statements) ] => BlockNode."

	| variableNodes temporaryBlockVariables start |

	variableNodes _ OrderedCollection new.
	start _ prevMark + requestorOffset.
	"Gather parameters."
	[self match: #colon] whileTrue: [variableNodes addLast: (encoder autoBind: self argumentName)].
	(variableNodes size > 0 & (hereType ~~ #rightBracket) and: [(self match: #verticalBar) not]) ifTrue: [^self expected: 'Vertical bar'].

	temporaryBlockVariables _ self temporaryBlockVariables.
	self statements: variableNodes innerBlock: true.
	parseNode temporaries: temporaryBlockVariables.

	(self match: #rightBracket) ifFalse: [^self expected: 'Period or right bracket'].

	encoder noteSourceRange: (self endOfLastToken to: self endOfLastToken) forNode: parseNode.

	"The scope of the parameters and temporary block variables is no longer active."
	temporaryBlockVariables do: [:variable | variable scope: -1].
	variableNodes do: [:variable | variable scope: -1]