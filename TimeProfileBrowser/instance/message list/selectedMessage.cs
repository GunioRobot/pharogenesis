selectedMessage
	"Answer the source method for the currently selected message."

	| source |
	self setClassAndSelectorIn: 
			[:class :selector | 
			source := class sourceMethodAt: selector ifAbsent: [^'Missing'].
			Preferences browseWithPrettyPrint 
				ifTrue: 
					[source := class prettyPrinterClass 
								format: source
								in: class
								notifying: nil].
			self selectedClass: class.
			self selectedSelector: selector.
			^source asText makeSelectorBoldIn: class].
	^''