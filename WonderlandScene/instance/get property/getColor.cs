getColor
	"Return the scene's background color"

	| tmpArray |

	myColor ifNil: [ ^ nil ].

	tmpArray _ Array new:3.
	
	tmpArray at:1 put: (myColor red).
	tmpArray at:2 put: (myColor green).
	tmpArray at:3 put: (myColor blue).

	^ tmpArray.