mouseMove: evt
	"Drag our target around"
	| thePoint |
	thePoint _ target point: (evt position - positionOffset) from: owner.
	target setConstrainedPosition: thePoint hangOut: true.