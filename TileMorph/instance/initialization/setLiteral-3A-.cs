setLiteral: anObject

	| m already |
	already _ submorphs detect: [:aSubMorph  | aSubMorph isKindOf: UpdatingStringMorph] ifNone: [nil].
	already ifNotNil: [already delete].
	type _ #literal.
	m _ UpdatingStringMorph contents: ' ' font: ScriptingSystem fontForTiles.
	m target: self; getSelector: #literal; putSelector: #literal:.
	(anObject isKindOf: String) ifTrue: [m useStringFormat].
	self addMorph: m.
	self literal: anObject.
