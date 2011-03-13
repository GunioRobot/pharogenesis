doScale: evt with: scaleHandle
	"Update the scale of my target if it is scalable."

	| newExtent |
	newExtent _ (evt cursorPoint - positionOffset) - target topLeft.
	newExtent _ (newExtent max: minExtent) min: Display extent.
	target scaleToFit: newExtent.
	target scale = 1.0
		ifTrue: [scaleHandle color: Color yellow]
		ifFalse: [scaleHandle color: Color orange].
	scaleHandle position: evt cursorPoint - (scaleHandle extent // 2).
	self layoutChanged.
