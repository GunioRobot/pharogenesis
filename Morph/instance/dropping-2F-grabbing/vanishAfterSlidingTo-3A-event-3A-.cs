vanishAfterSlidingTo: aPosition event: evt

	| aForm aWorld startPoint endPoint |
	aForm _ self imageForm offset: 0@0.
	aWorld _ self world.
	startPoint _ evt hand fullBounds origin.
	self delete.
	aWorld displayWorld.
	endPoint _ aPosition.
	aForm slideFrom: startPoint  to: endPoint nSteps: 12 delay: 15.
	Preferences soundsEnabled ifTrue: [TrashCanMorph playDeleteSound].
