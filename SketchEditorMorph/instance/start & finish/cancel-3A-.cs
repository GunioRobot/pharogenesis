cancel: evt
	"Palette is telling us that the use wants to end the painting session.  "

	Cursor blank show.
	self deliverPainting: #cancel evt: evt.