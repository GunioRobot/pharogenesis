screenRectangle
	"If the receiver is currently in an mvc window, return its screen rectangle"

	| aWorld aBox |
	(aWorld _ self world) ifNil: [^ nil].
	(aBox _ aWorld viewBox) ifNil: [^ nil].
	^ (self fullBounds origin + aBox origin) extent: self extent