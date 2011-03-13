outermostWorldMorph

	| outer |
	outer _ self outermostMorphThat: [ :x | x isWorldMorph].
	outer ifNotNil: [^outer].
	self isWorldMorph ifTrue: [^self].
	^nil