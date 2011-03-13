implementorsNav: navSelector
	| selector implementors |
	selector := OBMetaNode named: 'Selector'.
	implementors := OBMetaNode named: 'Implementors'.
	
	selector 
		childAt: navSelector labeled: 'list' put: implementors;
		childAt: navSelector labeled: 'chase' put: (self chaseImplementorsNav: navSelector);
		filterClass: OBModalFilter.
	implementors 
		displaySelector: #indentedFullName;
		addActor: OBNodeActor new.

	^ selector