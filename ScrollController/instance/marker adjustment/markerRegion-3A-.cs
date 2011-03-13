markerRegion: aRectangle 
	"Set the area defined by aRectangle as the marker. Fill it with gray tone."

	Display fill: marker fillColor: scrollBar insideColor.
	marker region: aRectangle.
	marker _ marker align: marker topCenter with: self upDownLine @ (scrollBar top + 2) 