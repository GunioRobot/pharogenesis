addGlobalFlap
	| aMenu reply aFlapTab |
	aMenu _ MVCMenuMorph entitled: 'which edge should it stick to? '.
	#(left right top bottom) do:
		[:sym | aMenu add: sym action: sym].
	reply _ aMenu invokeAt: self currentHand position in: self currentWorld.
	reply ifNotNil:
		[aFlapTab _ self newFlapTitled: 'Untitled Flap' onEdge: reply.
		self addGlobalFlap: aFlapTab.
	self currentWorld addGlobalFlaps]
	
