fixLayout

	layout = #stagger 	ifTrue: [^self fixLayoutStagger].
	layout= #pile		ifTrue: [^self fixLayoutPile].

	^super fixLayout.

