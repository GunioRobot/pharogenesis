browseObsoleteRefs: aClassNode as: oldName 
	| binding |
	binding := aClassNode theNonMetaClass environment 
				associationAt: aClassNode theNonMetaClass name.
	(SystemNavigation default allCallsOn: binding) isEmpty 
		ifFalse: [OBReferencesBrowser
					browseRoot: aClassNode
					title: 'Obsolete references to']