translateTestSuite		"DynamicInterpreter translateTestSuite"

	"Translate a collection of 32 source files with the various options encoded as:
		D/d		- enable/disable decoding of literal frame at translation time
		H/h		- enable/disable hash bits in method cache
		M/m	- enable/disable macro opcodes
		I/i		- enable/disable inline cache
		E/e		- enable/disable eager flush"
	
	| enabled disabled code |
	FreezeConfiguration _ true.
	enabled _ 'DHMIE'.
	disabled _ 'dhmie'.
	0 to: 31 do: [:flags |
		code _ 'xxxxx'.
		code at: 1 put: (((EagerInlineCacheFlush _ (flags bitAnd: 1) = 1)
			ifTrue: [enabled] ifFalse: [disabled]) at: 1).
		code at: 2 put: (((UseInlineCache _ (flags bitAnd: 2) = 2)
			ifTrue: [enabled] ifFalse: [disabled]) at: 2).
		code at: 3 put: (((UseMacroOpcodes _ (flags bitAnd: 4) = 4)
			ifTrue: [enabled] ifFalse: [disabled]) at: 3).
		code at: 4 put: (((UseMethodCacheHashBits _ (flags bitAnd: 8) = 8)
			ifTrue: [enabled] ifFalse: [disabled]) at: 4).
		code at: 5 put: (((DecodeLiteralConstants _ (flags bitAnd: 16) = 16)
			ifTrue: [enabled] ifFalse: [disabled]) at: 5).
		DecodeLiteralSelectors	_ DecodeLiteralConstants.
		DecodeLiteralVariables	_ DecodeLiteralConstants.
		Transcript cr; print: flags; tab; show: 'translating ' , code; tab.

		Transcript print: (Time millisecondsToRun: [
			self translate: 'translator-' , code , '.c'
				doInlining: true
				doAssertions: false]).
	].
	FreezeConfiguration _ false.
	self initializeConfiguration.
