defaultMetaNode
	| class method message var |
	class := OBMetaNode named: 'Class'.
	var := OBMetaNode named: 'Variable'.
	method := OBMetaNode named: 'Method'.
	message := OBMetaNode named: 'Message'.
	class
		addActor: OBNodeActor new;
		childAt: #instanceVariables labeled: 'instance' put: var;
		childAt: #classVariables labeled: 'class' put: var;
		filterClass: OBModalFilter.
	var
		childAt: #accessors put: method;
		addActor: OBNodeActor new;
		filterClass: OBModalFilter.
	method
		displaySelector: #fullName;
		addActor: OBNodeActor new;
		childAt: #senders put: message;
		filterClass: OBModalFilter.
	message
		displaySelector: #fullName;
		addActor: OBNodeActor new;
		childAt: #senders put: message;
		filterClass: OBModalFilter.
	
	^ class