scrollUp
	| markerForm firstTime |
	self changeCursor: Cursor up.
	sensor anyButtonPressed ifTrue:
	  [markerForm := Form fromDisplay: marker.
	  Display fill: marker fillColor: scrollBar insideColor.
	  firstTime := true.
	  markerForm 
		follow: 
			[self scrollViewUp ifTrue:
				[marker := marker translateBy: 0 @
					((self markerDelta negated 
						min: scrollBar inside bottom - marker bottom) 
						max: scrollBar inside top - marker top).
				firstTime
					ifTrue: [
						"pause before scrolling repeatedly"
						(Delay forMilliseconds: 250) wait.
						firstTime := false.
					] ifFalse: [
						(Delay forMilliseconds: 50) wait.
					].
				].
			marker origin] 
		while: [sensor anyButtonPressed].
	  self moveMarker.]