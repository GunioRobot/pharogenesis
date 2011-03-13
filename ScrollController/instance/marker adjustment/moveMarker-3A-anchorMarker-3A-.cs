moveMarker: anInteger anchorMarker: anchorMarker
	"Update the marker so that is is translated by an amount corresponding to 
	a distance of anInteger, constrained within the boundaries of the scroll 
	bar.  If anchorMarker ~= nil, display the border around the area where the
	marker first went down."

	Display fill: marker fillColor: scrollBar insideColor.
	anchorMarker = nil
		ifFalse: [Display border: anchorMarker width: 1 fillColor: Color gray].
	marker _ marker translateBy: 0 @
				((anInteger min: scrollBar inside bottom - marker bottom) max:
					scrollBar inside top - marker top).
	marker displayOn: Display