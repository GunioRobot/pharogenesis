selectedMessage
	"Answer the source method for the currently selected message."
	| source |
	self setClassAndSelectorIn: [:class :selector | 
		source _ class sourceMethodAt: selector ifAbsent: [^ 'Missing'].
		Preferences browseWithPrettyPrint ifTrue:
			[source _ class compilerClass new
				format: source in: class notifying: nil decorated: false].
		self selectedClass: class.
		self selectedSelector: selector.
		^ source asText makeSelectorBoldIn: class].
	^''