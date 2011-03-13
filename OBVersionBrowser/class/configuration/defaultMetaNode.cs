defaultMetaNode
	| version |
	version := OBMetaNode named: 'Version'.
	version addActor: OBNodeActor new.
	^ (OBMetaNode named: 'Method') 
		childAt: #versions put: version.