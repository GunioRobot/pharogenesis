submorphBounds
	"Private. Compute the actual full bounds of the receiver"
	| box subBox |
	submorphs do: [:m | 
		(m visible) ifTrue: [
			subBox _ m fullBounds.
			box 
				ifNil:[box _ subBox copy]
				ifNotNil:[box _ box quickMerge: subBox]]].
	box ifNil:[^self bounds]. "e.g., having submorphs but not visible"
	^ box origin asIntegerPoint corner: box corner asIntegerPoint
