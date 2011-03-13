scrollAbsolute
	| markerOutline oldY markerForm |
	self changeCursor: Cursor rightArrow.

	oldY := -1.
	sensor anyButtonPressed ifTrue: 
	  [markerOutline := marker deepCopy.
	  markerForm := Form fromDisplay: marker.
	  Display fill: marker fillColor: scrollBar insideColor.
	  Display border: markerOutline width: 1 fillColor: Color gray.
	  markerForm 
		follow: 
			[oldY ~= sensor cursorPoint y
				ifTrue: 
					[oldY := sensor cursorPoint y.
					marker := marker translateBy: 
					  0 @ ((oldY - marker center y 
						min: scrollBar inside bottom - marker bottom) 
						max: scrollBar inside top - marker top).
					self scrollView].
				marker origin] 
		while: [sensor anyButtonPressed].

	  Display fill: markerOutline fillColor: scrollBar insideColor.
	  self moveMarker]