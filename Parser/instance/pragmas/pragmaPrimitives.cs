pragmaPrimitives
	| primitives |
	primitives := self properties pragmas select: [ :each | 
		#( primitive: primitive:module: ) 
			includes: each keyword ].
	primitives isEmpty 
		ifTrue: [ ^ 0 ].
	primitives size = 1 
		ifFalse: [ ^ self notify: 'Ambigous primitives' ].
	^ primitives first message sendTo: self.