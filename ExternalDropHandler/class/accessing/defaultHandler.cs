defaultHandler
	DefaultHandler ifNil: [DefaultHandler _ ExternalDropHandler type: nil extension: nil action: [:dropStream | dropStream edit]].
	^DefaultHandler