isPrototypeTurtlePlayer

	^ false.
"
	costume ifNil: [^ false].
	^ costume renderedMorph isMemberOf: KedamaTurtleMorph
"