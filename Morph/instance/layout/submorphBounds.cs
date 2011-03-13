submorphBounds
	"Private. Compute the actual full bounds of the receiver"
	| box subBox |
	submorphs do: [:m | 
		(m visible) ifTrue: [
			subBox := m fullBounds.
			box 
				ifNil:[box := subBox copy]
				ifNotNil:[box := box quickMerge: subBox]]].
	box ifNil:[^self bounds]. "e.g., having submorphs but not visible"
	^ box origin asIntegerPoint corner: box corner asIntegerPoint
