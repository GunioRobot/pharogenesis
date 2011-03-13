fitOnScreen
	"19 sept 2000 - allow flaps in any paste up"
	| constrainer |
	constrainer _ owner ifNil: [self].
	self flapShowing "otherwise no point in doing this"
		ifTrue:[self spanWorld].
	self orientation == #vertical ifTrue: [
		self top: ((self top min: (constrainer bottom- self height)) max: constrainer top).
	] ifFalse: [
		self left: ((self left min: (constrainer right - self width)) max: constrainer left).
	].
	self flapShowing ifFalse: [self positionObject: self atEdgeOf: constrainer].
