scrollDown
	| markerForm firstTime |
	self changeCursor: Cursor down.
	sensor anyButtonPressed ifTrue:
	  [markerForm _ Form fromDisplay: marker.
	  Display fill: marker fillColor: scrollBar insideColor.
	  firstTime _ true.
	  markerForm 
		follow: 
			[self scrollViewDown ifTrue:
				[marker _ marker translateBy: 0 @
					((self markerDelta negated 
						min: scrollBar inside bottom - marker bottom) 
						max: scrollBar inside top - marker top).
				firstTime
					ifTrue: [
						"pause before scrolling repeatedly"
						(Delay forMilliseconds: 250) wait.
						firstTime _ false.
					] ifFalse: [
						(Delay forMilliseconds: 50) wait.
					].
				].
			marker origin] 
		while: [sensor anyButtonPressed].
	  self moveMarker.]