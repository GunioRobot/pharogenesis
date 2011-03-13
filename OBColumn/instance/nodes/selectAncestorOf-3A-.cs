selectAncestorOf: aNode
	| ancestor |
	ancestor _ self filter selectAncestorOf: aNode withParent: self parent.
	ancestor ifNotNil:
		[self 
			getChildren; 
			changed: #list;
			select: ancestor.
		panel selected: self].
	^ ancestor