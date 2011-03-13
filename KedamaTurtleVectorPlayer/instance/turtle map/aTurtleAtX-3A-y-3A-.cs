aTurtleAtX: xPos y: yPos

	| w x y index who stub |
	turtleMapValid ifFalse: [
		self makeTurtlesMap.
	].

	w _ kedamaWorld dimensions x.
	x _ xPos truncated.
	y _ yPos truncated.
	x < 0 ifTrue: [^ nil].
	x >= w ifTrue: [^ nil].
	y < 0 ifTrue: [^ nil].
	y >= kedamaWorld dimensions y ifTrue: [^ nil].
	index _ (w * y) + x + 1.
	who _ turtlesMap at: index.
	who = 0 ifTrue: [^ nil].
	who = lastWho ifTrue: [^ lastWhoStub].
	stub _ exampler clonedSequentialStub.
	stub who: who.
	lastWho _ who.
	^ lastWhoStub _ stub.
