defaultMetaNode
	^ self 
		addTo: (OBMetaNode named: 'RootClass')
		class: #classHierarchy 
		comment: #commentHierarchy 
		metaclass: #metaclassHierarchy.
