browseUnsentMessages
	"DynamicInterpreter browseUnsentMessages"

	| sent destClasses sourceClasses unsent |
	destClasses _ { DynamicInterpreter. DynamicTranslator. DynamicContextCache }.
	sourceClasses _ destClasses , { BitBltSimulation. ObjectMemory. DynamicInterpreterSimulator }.
	sent _ IdentitySet new.
	sourceClasses do: [:cls |
		cls selectors do: [:sel |
			sent addAll: ((cls compiledMethodAt: sel) literals select: [:lit | lit isMemberOf: Symbol])]].
	sent
		addAll: DynamicInterpreter primitiveTable;
		addAll: DynamicInterpreter translationTable;
		addAll: DynamicInterpreter opcodeTable.
	unsent _ Set new.
	destClasses do: [:cls |
		unsent addAll: ((cls selectors reject: [:sel | sent includes: sel])
						collect: [:sel | cls name , ' ' , sel])].

	Smalltalk browseMessageList: unsent asSortedCollection name: 'unused methods'.