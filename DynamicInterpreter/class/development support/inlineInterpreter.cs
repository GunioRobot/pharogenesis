inlineInterpreter
	"CacheInterpreter inlineInterpreter"

	"Browse all inlined methods in class Interpreter"

	Smalltalk browseMessageList: (Interpreter allCallsOn: #inline:)
			name: 'Interpreter senders of inline:'
			autoSelect: #inline: