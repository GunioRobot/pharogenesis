loadCursors
	"Display the form containing the cursors.  Transparent is (Color r: 1.0 g: 0 b: 1.0).  Grab the forms one at a time, and they are stored away.
	self loadCursors.	"

	| button transp cursor map |
	transp _ Color r: 1.0 g: 0 b: 1.0.
	map _ Color indexedColors copy.	"just in case"
	1 to: 256 do: [:ind | (map at: ind) = transp ifTrue: 
				[map at: ind put: Color transparent]].

	#(erase: eyedropper: fill: paint: rect: ellipse: polygon: line: star: ) do: [:sel |
		self inform: 'Rectangle for ',sel.
		cursor _ ColorForm fromUser.
		cursor colors: map.	"share it"
		button _ self submorphNamed: sel.
		button arguments at: 3 put: cursor].
