translate: fileName doInlining: inlineFlag doAssertions: assertionFlag fromClasses: classList

	| cg |
	cg _ CCodeGenerator new initialize.

	self initialize.
	classList do: [:class | cg addClass: class].
	classList do: [:class | class declareCVarsIn: cg].

	cg storeCodeOnFile: fileName doInlining: inlineFlag doAssertions: assertionFlag.