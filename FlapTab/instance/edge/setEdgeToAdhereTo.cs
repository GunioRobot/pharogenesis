setEdgeToAdhereTo
	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	#(left top right bottom) do:
		[:sym | aMenu add: sym asString target: self selector:  #setEdge: argument: sym].
	aMenu popUpEvent: self currentEvent