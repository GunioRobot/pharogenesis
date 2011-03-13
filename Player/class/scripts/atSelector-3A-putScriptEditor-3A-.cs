atSelector: aSelector putScriptEditor: aScriptEditor
	| selSym  aUserScript |

	selSym _ aSelector asSymbol.
	scripts ifNil: [scripts _ IdentityDictionary new].
	aUserScript _ scripts at: selSym ifAbsent: [nil].
	aUserScript ifNil:
		[aUserScript _ UserScript new player: self flagshipInstance selector: selSym.
		scripts at: selSym put: aUserScript].
	aUserScript currentScriptEditor: aScriptEditor