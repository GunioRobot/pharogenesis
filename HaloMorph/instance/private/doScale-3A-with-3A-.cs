doScale: evt with: scaleHandle
	"Update the scale of my target if it is scalable."
	| newExtent newHandlePos |
	newHandlePos _ evt cursorPoint - (scaleHandle extent // 2).
	newExtent _ (target pointFromWorld: newHandlePos) - target center * 2.
	evt shiftPressed ifTrue: [newExtent _ (newExtent x max: newExtent y) asPoint].
	target scaleToFit: ((newExtent max: minExtent) min: Display extent).
	target scale = 1.0
		ifTrue: [scaleHandle color: Color yellow]
		ifFalse: [scaleHandle color: Color orange].
	scaleHandle position: newHandlePos.
	self layoutChanged.
