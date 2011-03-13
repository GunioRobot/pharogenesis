asMorphicSyntaxIn: parent
	
	^parent
		methodNodeInner: self 
		selectorOrFalse: selectorOrFalse 
		precedence: precedence 
		arguments: arguments 
		temporaries: temporaries 
		primitive: primitive 
		block: block
