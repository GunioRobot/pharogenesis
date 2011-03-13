translateOn: cg inlining: inlineFlag to: fullName local: localFlag
	"do the actual translation"
	| theClass |
	theClass _ self.
	[theClass == Object] whileFalse:[
		cg addClass: theClass.
		theClass declareCVarsIn: cg.
		theClass _ theClass superclass].
	cg storeCodeOnFile: fullName doInlining: inlineFlag.
