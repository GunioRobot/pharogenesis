install

	"hide the hardware cursor, since hand will draw it"
	Cursor blank show.
	self viewBox: Display boundingBox.
	hands do: [:h | h initForEvents].
	self displayWorld.
