isEdge: edge
	| type |
	type _ self objectTypeOf: edge.
	type > GEPrimitiveEdgeMask ifTrue:[^false].
	^((self objectTypeOf: edge) bitAnd: GEPrimitiveEdgeMask) ~= 0