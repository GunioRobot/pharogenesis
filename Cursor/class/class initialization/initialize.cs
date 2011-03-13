initialize
	"Create all the standard cursors
		Cursor origin
		Cursor rightArrow
		Cursor menu
		Cursor corner
		Cursor read
		Cursor write
		Cursor wait
		Cursor blank
		Cursor xeq
		Cursor square
		Cursor normal
		Cursor crossHair
		Cursor marker
		Cursor up
		Cursor down
		Cursor move"

		self initOrigin.
		self initRightArrow.
		self initMenu.
		self initCorner.
		self initRead.
		self initWrite.
		self initWait.
		BlankCursor _ Cursor new.
		self initXeq.
		self initSquare.
		self initNormal.
		self initCrossHair.
		self initMarker.
		self initUp.
		self initDown.
		self initMove.

		"Cursor initialize"
