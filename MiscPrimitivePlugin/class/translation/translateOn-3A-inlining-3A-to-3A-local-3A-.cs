translateOn: cg inlining: inlineFlag to: fullName local: localFlag
	"MiscPrimitivePlugin translateLocally"
	| code |
	code _ cg codeStringForPrimitives: self translatedPrimitives.
	self storeString: code onFileNamed: fullName.