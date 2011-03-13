atSelector: aSelector putScriptEditor: aScriptEditor
	"Place the given script editor in my directory of script editors, at the given selector"

	| selSym  aUniclassScript |
	selSym _ aSelector asSymbol.
	scripts ifNil: [scripts _ IdentityDictionary new].
	aUniclassScript _ scripts at: selSym ifAbsent: [nil].
	aUniclassScript ifNil:
		[aUniclassScript _ UniclassScript new playerClass: aScriptEditor playerScripted class selector: selSym.
		scripts at: selSym put: aUniclassScript].
	aUniclassScript currentScriptEditor: aScriptEditor