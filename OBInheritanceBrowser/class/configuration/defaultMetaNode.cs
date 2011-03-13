defaultMetaNode
	| method root |
	method := OBMetaNode named: 'Method'.
	root := OBMetaNode named: 'Root'.
	root
		childAt: #children put: method.
	method
		displaySelector: #fullName;
		childAt: #overrides put: method;
		addActor: OBNodeActor new.
	^ root