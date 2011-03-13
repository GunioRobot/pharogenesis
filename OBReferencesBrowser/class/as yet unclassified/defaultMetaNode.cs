defaultMetaNode
	| class method |
	class := OBMetaNode named: 'Class'.
	method := OBMetaNode named: 'References'.
	
	class
		childAt: #users put: method;
		addActor: OBNodeActor new.
	method
		displaySelector: #fullName;
		addActor: OBNodeActor new.
		
	^ class