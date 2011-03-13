selectedMessage
	"Answer the source method for the currently selected message.  Allow class comment, definition, and hierarchy."

	| source |
	self setClassAndSelectorIn: [:class :selector | 
		selector first isUppercase ifFalse:
			[source _ class sourceMethodAt: selector.
			currentCompiledMethod _ class compiledMethodAt: selector ifAbsent: [nil]..
			^ source asText makeSelectorBoldIn: self selectedClassOrMetaClass].
		selector = #Comment ifTrue: [^ class comment].
		selector = #Definition ifTrue: [^ class definitionST80: Preferences printAlternateSyntax not].
		selector = #Hierarchy ifTrue: [^ class printHierarchy].
		source _ class sourceMethodAt: selector.
		currentCompiledMethod _ class compiledMethodAt: selector ifAbsent: [nil].
		Preferences browseWithPrettyPrint ifTrue:
			[source _ class compilerClass new
				format: source in: class notifying: nil decorated: Preferences colorWhenPrettyPrinting].
		^ source asText makeSelectorBoldIn: self selectedClassOrMetaClass]