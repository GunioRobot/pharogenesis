createBox
	"create a button with default to be used in the label area"
	"Transcript show: self paneColor asString;  
	cr."
	| box boxBorderWidth |
	box := IconicButton new.
	box color: Color transparent;
		 target: self;
		 useRoundedCorners.

	boxBorderWidth := (Preferences alternativeWindowLook
					and: [Preferences alternativeWindowBoxesLook])
				ifTrue: [1]
				ifFalse: [0].
	box borderWidth: boxBorderWidth.

	^ box