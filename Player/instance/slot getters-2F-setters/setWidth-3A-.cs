setWidth: aWidth
	"Set the width"

	| cost widthToUse |
	cost _ self costume.
	cost isWorldMorph ifTrue: [^ self].
	cost isLineMorph
		ifTrue:
			[^ cost unrotatedWidth: aWidth].
	widthToUse _ cost isRenderer
		ifTrue:
			[aWidth / cost scaleFactor]
		ifFalse:
			[aWidth].
	cost renderedMorph width: widthToUse