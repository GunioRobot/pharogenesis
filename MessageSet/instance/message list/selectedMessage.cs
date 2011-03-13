selectedMessage
	"Answer the source method for the currently selected message."
	| source |
	self setClassAndSelectorIn: [:class :selector | 
		source _ class sourceMethodAt: selector ifAbsent: [^ 'Missing'].
		^ source asText makeSelectorBoldIn: self selectedClassOrMetaClass]