block
	"Allow the user to fill a rectangle with the gray tone and mode currently 
	selected."

	| rectangle originRect |
	originRect := (Sensor cursorPoint grid: grid) extent: 2 @ 2.
 	rectangle := Cursor corner showWhile:
		[originRect newRectFrom:
			[:f | f origin corner: (Sensor cursorPoint grid: grid)]].
	rectangle isNil 
		ifFalse:
		  [sensor waitNoButton.
		   Display
					fill: (rectangle intersect: view insetDisplayBox)
					rule: mode
					fillColor: color.
		   hasUnsavedChanges contents: true.]