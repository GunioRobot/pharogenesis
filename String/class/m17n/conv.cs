conv

	| str cand classes oldVars newVars |
	oldVars _ String classVarNames asArray.
	newVars _ OrderedCollection new: oldVars size.
	oldVars do: [:var |
		newVars add: 'A', var.
		String addClassVarName: 'A', var.
	].
	newVars _ newVars asArray.

	str _ String streamContents: [:strm |
		oldVars do: [:var |
			strm nextPutAll: 'A', var, ' _ ', var, '.\' withCRs.
		].
	].
	Compiler evaluate: str for: String logged: false.
	String class removeSelector: #DoIt.

"	(String allMethodCategoriesIntegratedThrough: String) do: [:cat |
		AbstractString organization addCategory: cat
	].
"

	classes _ Array with: String with: String class with: Symbol with: Symbol class.
	classes do: [:cls |
		cand _ Set new.
		oldVars do: [:var |
			((cls allCallsOn: (String classPool associationAt: var asSymbol)) select: [:meth | meth classSymbol = cls theNonMetaClass name]) do: [:meth |
				cand add: meth methodSymbol.
			].
		].
		cand asArray do: [:sel |
			str _ String getTempMethodStringFrom: (cls sourceCodeAt: sel) string replaceVars: oldVars withVars: newVars.
			cls compile: str classified: (cls organization categoryOfElement: sel).
		].
	].

	oldVars do: [:k | String removeClassVarName: k].
	oldVars do: [:var |
		(Smalltalk at: #AbstractString) addClassVarName: var.
	].

	str _ String streamContents: [:strm |
		oldVars do: [:var |
			strm nextPutAll: var, ' _ ', 'A', var, '.\' withCRs.
		].
	].
	Compiler evaluate: str for: String logged: false.
	String class removeSelector: #DoIt.

	classes _ Array with: String with: String class with: Symbol with: Symbol class.
	classes do: [:cls |
		cand _ Set new.
		newVars do: [:var |
			((cls allCallsOn: (String classPool associationAt: var asSymbol)) select: [:meth | meth classSymbol = cls theNonMetaClass name]) do: [:meth |
				cand add: meth methodSymbol.
			].
		].
		cand asArray do: [:sel |
			str _ String getTempMethodStringFrom: (cls sourceCodeAt: sel) string replaceVars: newVars withVars: oldVars.
			cls compile: str classified: (cls organization categoryOfElement: sel).
		].
	].

	newVars do: [:k | String removeClassVarName: k].
