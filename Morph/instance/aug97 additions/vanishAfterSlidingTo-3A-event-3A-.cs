vanishAfterSlidingTo: aPosition event: evt

	| aForm aWorld origin startPoint endPoint |
	aForm _ self imageForm offset: 0@0.
	aWorld _ self world.
	origin _ aWorld viewBox origin.
	startPoint _ evt hand fullBounds origin + origin.
	self delete.
	aWorld displayWorld.
	endPoint _ aPosition + origin.
	aForm slideFrom: startPoint  to: endPoint nSteps: 12 delay: 15.
	aWorld soundsEnabled ifTrue: [TrashCanMorph playDeleteSound].
