newWorldExtent: aPoint
	"Answer an event that records a WorldMorph window size change."

	^ self basicNew setType: #worldExtent
		cursorPoint: aPoint
		buttons: 0
		keyValue: 0
