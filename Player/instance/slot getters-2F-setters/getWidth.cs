getWidth
	"Answer the width of the object"

	| aWidth cost |
	((cost _ self costume) isLineMorph) "annoying special case"
		ifTrue:
			[^ cost unrotatedWidth].
	aWidth _ cost renderedMorph width.  "facing upward when unrotated"

	cost isRenderer
		ifTrue:
			[aWidth _ aWidth * cost scaleFactor].
	^ aWidth