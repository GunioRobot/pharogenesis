updateIsNeeded
	"Return true if the display needs to be updated."

	^ totalRepaint or: [invalidRects size > 0]
