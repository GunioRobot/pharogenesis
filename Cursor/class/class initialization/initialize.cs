initialize
	"Create all the standard cursors..."
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
		self initNormalWithMask.
		self initCrossHair.
		self initMarker.
		self initUp.
		self initDown.
		self initMove.

		self makeCursorsWithMask.

		"Cursor initialize"
