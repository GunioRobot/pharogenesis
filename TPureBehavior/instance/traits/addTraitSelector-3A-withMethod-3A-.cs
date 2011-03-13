addTraitSelector: aSymbol withMethod: aCompiledMethod
	"Add aMethod with selector aSymbol to my
	methodDict. aMethod must not be defined locally."

	| source methodAndNode |
	self assert: [(self includesLocalSelector: aSymbol) not].
	self ensureLocalSelectors.
		
	source := aCompiledMethod getSourceReplacingSelectorWith: aSymbol.
	methodAndNode  := self
		compile: source
		classified: nil
		notifying: nil
		trailer: #(0 0 0 0)
		ifFail: [^nil].
	methodAndNode method putSource: source fromParseNode: methodAndNode node inFile: 2
		withPreamble: [:f | f cr; nextPut: $!; nextChunkPut: 'Trait method'; cr].
			
	self basicAddSelector: aSymbol withMethod: methodAndNode method