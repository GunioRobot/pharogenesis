pragmaPrimitives
	| pragmas primitives |
	self properties pragmas isEmpty
		ifTrue: [ ^ 0 ].
	pragmas := Pragma allNamed: #primitive from: self class to: Parser.
	primitives := self properties pragmas select: [ :prim |
		pragmas anySatisfy: [ :prag | 
			prag selector = prim keyword ] ].
	primitives isEmpty 
		ifTrue: [ ^ 0 ].
	primitives size = 1 
		ifFalse: [ ^ self notify: 'Ambigous primitives' ].
	^ primitives first message sendTo: self