selectedMessage
	"Answer the source method for the currently selected message.  Allow class comment, definition, and hierarchy."
	self setClassAndSelectorIn: [:class :selector | 
		selector first isUppercase ifFalse: [^ class sourceMethodAt: selector].
		selector = #Comment ifTrue: [^ class comment].
		selector = #Definition ifTrue: [^ class definition].
		selector = #Hierarchy ifTrue: [^ class printHierarchy].
		^ class sourceMethodAt: selector].