customizeCase: caseParseTree forVar: varName from: firstIndex to: lastIndex
	"Return a collection of copies of the given parse tree, each of which has the value of the case index substituted for the given variable."

	| newCases dict newCase |
	newCases _ OrderedCollection new.
	firstIndex to: lastIndex do: [ :caseIndex |
		dict _ Dictionary new.
		dict at: varName put: (TConstantNode new setValue: caseIndex).
		newCase _ caseParseTree copyTree bindVariableUsesIn: dict.
		self fixSharedCodeBlocksForCase: caseIndex in: newCase.
		newCases addLast: newCase.
	].
	^ newCases