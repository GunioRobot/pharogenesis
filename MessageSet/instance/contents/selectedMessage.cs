selectedMessage
	"Answer the source method for the currently selected message."

	| source |

	self setClassAndSelectorIn: [:class :selector | 
		class ifNil: [^ 'Class vanished'].
		source _ class sourceMethodAt: selector ifAbsent:
			[currentCompiledMethod _ nil.
			^ 'Missing'].
		currentCompiledMethod _ class compiledMethodAt: selector ifAbsent: [nil].
		self showingDocumentation ifTrue:
			[^ self commentContents].

		Preferences browseWithPrettyPrint ifTrue:
			[source _ class compilerClass new
				format: source in: class notifying: nil decorated: Preferences colorWhenPrettyPrinting].
		self showDiffs ifTrue:
			[source _ self diffFromPriorSourceFor: source].
		^ source asText makeSelectorBoldIn: class]