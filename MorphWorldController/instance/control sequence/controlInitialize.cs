controlInitialize
	"This window is becoming active."

	"hide the hardware cursor, since hand will draw it"
	Cursor blank show.
	"In case of, eg, inspect during balloon help..."
	BalloonMorph removeCurrentBalloon.
	model hands do: [:h | h initForEvents].
	view displayView.  "initializes the WorldMorph's canvas"
