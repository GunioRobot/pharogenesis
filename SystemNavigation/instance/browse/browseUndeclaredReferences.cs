browseUndeclaredReferences
	"from Cuis: 0058-browseUndeclared.1"
	"SystemNavigation default"
	
	Undeclared removeUnreferencedKeys.
	Undeclared keys do: [ :k |
		self
			browseMessageList: (self allCallsOn: (Undeclared associationAt: k))
			name: 'References to Undeclared: ', k printString ]