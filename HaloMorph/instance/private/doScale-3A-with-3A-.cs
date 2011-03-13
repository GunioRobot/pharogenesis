doScale: evt with: scaleHandle
	"Update the scale of my target if it is scalable."
	| newHandlePos |
	evt hand obtainHalo: self.
	newHandlePos _ evt cursorPoint - (scaleHandle extent // 2).
	target scaleToMatch: newHandlePos.
	target scale = 1.0
		ifTrue: [scaleHandle color: Color yellow]
		ifFalse: [scaleHandle color: Color orange].
	scaleHandle position: newHandlePos.
	self layoutChanged.
