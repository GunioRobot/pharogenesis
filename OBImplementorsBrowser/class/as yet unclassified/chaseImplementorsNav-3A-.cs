chaseImplementorsNav: navSelector
	| message implementor |
	message := OBMetaNode named: 'Message'.
	implementor := OBMetaNode named: 'Implementor'.
	implementor
		displaySelector: #indentedFullName;
		childAt: #messages put: message;
		addActor: OBNodeActor new.
	message
		childAt: navSelector labeled: 'implementors' put: implementor;
		addActor: OBNodeActor new.
	^ implementor