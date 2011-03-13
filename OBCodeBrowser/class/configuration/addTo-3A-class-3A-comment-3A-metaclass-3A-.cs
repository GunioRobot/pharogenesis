addTo: root class: classSel comment: commentSel metaclass: metaclassSel 
	| class metaclass comment methodCategory method allMethodCategory |
	class := OBMetaNode named: 'Class'.
	comment := OBMetaNode named: 'ClassComment'.
	metaclass := OBMetaNode named: 'Metaclass'.
	allMethodCategory := OBMetaNode named: 'AllMethodCategory'.
	methodCategory := OBMetaNode named: 'MethodCategory'.
	method := OBMetaNode named: 'Method'.
	root
		childAt: classSel
			labeled: 'instance'
			put: class;
		childAt: commentSel
			labeled: '?'
			put: comment;
		childAt: metaclassSel
			labeled: 'class'
			put: metaclass;
		addActor: (OBNodeActor onNodeClass: OBClassCategoryNode);
		addActor: OBCategoryActor new;
		filterClass: OBModalFilter.
	class
		displaySelector: #indentedName;
		childAt: #allCategory put: allMethodCategory;
		childAt: #categories put: methodCategory;
		addActor: OBNodeActor new;
		addActor: OBClassActor new.
	comment 
		displaySelector: #indentedName;
		addActor: OBNodeActor new.
	metaclass
		displaySelector: #indentedName;
		childAt: #allCategory put: allMethodCategory;
		childAt: #categories put: methodCategory;
		addActor: OBNodeActor new;
		addActor: OBClassActor new.
	allMethodCategory
		childAt: #methods put: method;
		addActor: (OBNodeActor onNodeClass: OBMethodCategoryNode).
	methodCategory
		childAt: #methods put: method;
		addActor: OBCategoryActor new;
		addActor: (OBNodeActor onNodeClass: OBMethodCategoryNode).
	method addActor: OBNodeActor new.
	^ root