moveMarkerTo: aRectangle 
	"Same as markerRegion: aRectangle; moveMarker, except a no-op if the marker
	 would not move."

	(aRectangle height = marker height and: [self viewDelta = 0]) ifFalse:
		[self markerRegion: aRectangle.
		self moveMarker]