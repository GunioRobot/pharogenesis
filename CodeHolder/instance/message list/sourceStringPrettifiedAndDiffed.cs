sourceStringPrettifiedAndDiffed
	"Answer a copy of the source code for the selected message, transformed by diffing and pretty-printing exigencies"

	| class selector sourceString |
	class _ self selectedClassOrMetaClass.
	selector _ self selectedMessageName.
	(class isNil or: [selector isNil]) ifTrue: [^ 'missing'].

	sourceString _ class ultimateSourceCodeAt: selector ifAbsent: [^ 'error'].
	self validateMessageSource: sourceString forSelector: selector.

	(#(prettyPrint colorPrint prettyDiffs altSyntax) includes: contentsSymbol) ifTrue:
		[sourceString _ class compilerClass new
			format: sourceString in: class notifying: nil contentsSymbol: contentsSymbol].
	self showingAnyKindOfDiffs ifTrue:
		[sourceString _ self diffFromPriorSourceFor: sourceString].

	^ sourceString