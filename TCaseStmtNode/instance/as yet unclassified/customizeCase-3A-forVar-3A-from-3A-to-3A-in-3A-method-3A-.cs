customizeCase: caseParseTree forVar: varName from: firstIndex to: lastIndex in: codeGen method: aTMethod
	"Return a collection of copies of the given parse tree, each of which has the value of the case index substituted for the given variable."

	| newCases dict newCase |
	newCases _ OrderedCollection new.
	firstIndex to: lastIndex do: [ :caseIndex |
		dict _ Dictionary new.
		dict at: varName put: (TConstantNode new setValue: caseIndex).
		newCase _ caseParseTree copyTree bindVariableUsesIn: dict.
		self processSharedCodeBlocks: newCase forCase: caseIndex in: codeGen method: aTMethod.
		newCases addLast: newCase.
	].
	^ newCases