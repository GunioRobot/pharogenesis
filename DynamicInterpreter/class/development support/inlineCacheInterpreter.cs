inlineCacheInterpreter
	"CacheInterpreter inlineCacheInterpreter"

	"Browse all inlined methods in classes CacheInterpreter, ContextCache, and DynamicInterpreter"

	Smalltalk browseMessageList: (DynamicInterpreter allCallsOn: #inline:)
			name: 'CacheInterpreter senders of inline:'
			autoSelect: #inline: