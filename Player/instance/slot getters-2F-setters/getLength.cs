getLength
	"Answer the length of the object"

	| aLength cost |
	((cost  _ self costume) isLineMorph) "annoying special case"
		ifTrue:
			[^ cost unrotatedLength].
	aLength _ cost renderedMorph height.  "facing upward when unrotated"
	cost isRenderer
		ifTrue:
			[aLength _ aLength * cost scaleFactor].
	^ aLength