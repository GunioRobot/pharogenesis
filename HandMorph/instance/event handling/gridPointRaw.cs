gridPointRaw
	"Private! Returns the nearest grid point to the cursor to be used as the coordinate for the current event.  Do not include a cursor offset"

	| where |
	where _ Sensor cursorPoint.
	^ gridOn ifTrue: [where grid: grid]
			ifFalse: [where]
