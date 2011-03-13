setLiteral: anObject

	| m |
	type _ #literal.
	m _ UpdatingStringMorph contents: ' ' font: ScriptingSystem fontForTiles.  "BUT this doesn't do it, damnit"
	m target: self; getSelector: #literal; putSelector: #literal:.
	self addMorph: m.
	self literal: anObject.
