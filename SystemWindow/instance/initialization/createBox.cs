createBox
	"create a button with default to be used in the label area"
	"Transcript show: self paneColor asString;  
	cr."
	| box |
	box _ IconicButton new.
	box color: Color transparent;
		 target: self;
		 useSquareCorners;
		 borderWidth: 0.

	^ box