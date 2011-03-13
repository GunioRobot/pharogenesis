defaultMetaNode
	| selector list chase |
	list := OBMetaNode named: 'Senders'.
	list 
		displaySelector: #fullName;
		addActor: OBNodeActor new.

	chase := OBMetaNode named: 'Send'.
	chase
		displaySelector: #fullName;
		childAt: #senders put: chase;
		addActor: OBNodeActor new.

	selector := OBMetaNode named: 'Selector'.	
	selector 
		childAt: #senders labeled: 'list' put: list;
		childAt: #senders labeled: 'chase' put: chase;
		filterClass: OBModalFilter.

	^ selector