save
	"Palette is telling us that the use wants to end the painting session.  "

	Cursor blank show.
	action == #polygon: ifTrue: [self polyFreeze].		"end polygon mode"
	^ self deliverPainting: #okay.