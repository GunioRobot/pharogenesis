closeStroke
	"Close the current stroke"
	lastPoint do:[:pt| lastPoint _ pt].
	lastPoint nextPoint: firstPoint.
	self simplifyLineFrom: firstPoint.
	firstPoint _ firstPoint nextPoint.
	self simplifyLineFrom: firstPoint.
	firstPoint _ firstPoint nextPoint.
	self simplifyLineFrom: firstPoint.
	firstPoint prevPoint nextPoint: nil.
	firstPoint prevPoint: nil.	