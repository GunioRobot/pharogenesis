slideToTrash: evt

	| aForm aWorld trash startPoint endPoint |
	aForm _ self imageForm offset: 0@0.
	aWorld _ self world.
	trash _ aWorld findA: TrashCanMorph.
	trash ifNil: [^ self].
	startPoint _ evt hand fullBounds origin.
	endPoint _ trash position.
	self delete.
	aWorld displayWorld.
	aForm slideFrom: startPoint to: endPoint nSteps: 12 delay: 15.
	trash acceptDroppingMorph: self event: evt.
