somethingAt: aPosition 
	| morphs morph |
	morphs _ self rootMorphsAt: aPosition.
	morphs notEmpty
		ifTrue: [morph _ morphs at: 1.
			(morph isKindOf: AtomicComponent)
				ifTrue: [^ morph]].
	^ nil