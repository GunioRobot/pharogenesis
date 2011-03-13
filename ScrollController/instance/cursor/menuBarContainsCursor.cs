menuBarContainsCursor
	"Answer whether the cursor is anywhere within the menu bar area."

	^ menuBar notNil and:
			[menuBar containsPoint: sensor cursorPoint]