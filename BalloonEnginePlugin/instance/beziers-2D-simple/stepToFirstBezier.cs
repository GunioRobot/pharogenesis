stepToFirstBezier
	"Initialize the current entry in the GET by stepping to the current scan line"
	self inline: true.
	^self stepToFirstBezierIn: (getBuffer at: self getStartGet) at: self currentYGet