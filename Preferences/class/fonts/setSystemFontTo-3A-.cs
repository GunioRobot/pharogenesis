setSystemFontTo: aFont
	"Establish the default text font and style"

	| aStyle newDefaultStyle |
	aFont ifNil: [^ self].
	aStyle _ aFont textStyle ifNil: [^ self].
	newDefaultStyle _ aStyle copy.
	newDefaultStyle defaultFontIndex: (aStyle fontIndexOf: aFont).
	TextConstants at: #DefaultTextStyle put: newDefaultStyle.
	Flaps replaceToolsFlap.
	ScriptingSystem resetStandardPartsBin