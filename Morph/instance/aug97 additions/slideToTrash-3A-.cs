slideToTrash: evt

	| aForm aWorld trash origin startPoint endPoint |
	aForm _ self imageForm offset: 0@0.
	aWorld _ self world.
	trash _ aWorld findA: TrashCanMorph.
	trash ifNil: [^ self].
	origin _ aWorld viewBox origin.
	startPoint _ evt hand fullBounds origin + origin.
	endPoint _ trash position + origin.
	self delete.
	aWorld displayWorld.
	aForm slideFrom: startPoint to: endPoint nSteps: 12 delay: 15.
	trash acceptDroppingMorph: self event: evt.
