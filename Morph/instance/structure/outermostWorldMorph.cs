outermostWorldMorph

	| outer |
	World ifNotNil:[^World].
	self flag: #arNote. "stuff below is really only for MVC"
	outer _ self outermostMorphThat: [ :x | x isWorldMorph].
	outer ifNotNil: [^outer].
	self isWorldMorph ifTrue: [^self].
	^nil