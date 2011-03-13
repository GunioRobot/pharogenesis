selectedMessage
	"Answer the source method for the currently selected message.  Allow class comment, definition, and hierarchy."

	| source |
	self setClassAndSelectorIn: [:class :selector | 
		selector first isUppercase ifFalse: [
			source _ class sourceMethodAt: selector.
			^ source asText makeSelectorBoldIn: self selectedClassOrMetaClass].
		selector = #Comment ifTrue: [^ class comment].
		selector = #Definition ifTrue: [^ class definition].
		selector = #Hierarchy ifTrue: [^ class printHierarchy].
		source _ class sourceMethodAt: selector.
		^ source asText makeSelectorBoldIn: self selectedClassOrMetaClass]