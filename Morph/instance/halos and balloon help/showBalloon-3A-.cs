showBalloon: msgString
	"Pop up a balloon containing the given string,
	first removing any existing BalloonMorphs in the world."

	| w balloon worldBounds |
	(w _ self world) ifNil: [^ self].
	w submorphsDo: [:m | (m isKindOf: BalloonMorph) ifTrue: [m delete]].
	balloon _ BalloonMorph string: msgString for: self balloonHelpAligner.
	balloon lock.
	w addMorphFront: balloon.
	"So that if the translation below makes it overlap the receiver, it won't
	interfere with the rootMorphsAt: logic and hence cause flashing.  Without
	this, flashing happens, believe me!"
	((worldBounds _ w bounds) containsRect: balloon bounds) ifFalse:
		[balloon bounds: (balloon bounds translatedToBeWithin: worldBounds)].
	self setProperty: #balloon toValue: balloon