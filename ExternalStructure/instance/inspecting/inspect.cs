inspect
	"Open an ExternalStructureInspector on the receiver.  Use basicInspect to get a normal (less useful) type of inspector."

	self class fields size > 0 
		ifTrue: [ExternalStructureInspector openOn: self withEvalPane: true]
		ifFalse: [super inspect]