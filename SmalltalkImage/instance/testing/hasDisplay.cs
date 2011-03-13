hasDisplay

	| arg i |
	i := -1.
	[(arg := SmalltalkImage current getSystemAttribute: i) isNil]
		whileFalse: [(#('-nodisplay' '-headless') includes: arg) ifTrue: [^ false].
			i := i - 1].
	^ true