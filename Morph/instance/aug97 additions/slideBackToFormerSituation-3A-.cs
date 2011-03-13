slideBackToFormerSituation: evt

	| aForm formerOwner formerPosition aWorld origin startPoint endPoint |
	aForm _ self imageForm offset: 0@0.
	formerOwner _ evt hand formerOwner.
	formerPosition _ evt hand formerPosition.
	aWorld _ self world.
	origin _ aWorld viewBox origin.
	startPoint _ evt hand fullBounds origin + origin.
	endPoint _ formerPosition + origin.
	self delete.
	aWorld displayWorld.
	aForm slideFrom: startPoint to: endPoint nSteps: 12 delay: 15.
	formerOwner addMorph: self.
	self position: formerPosition.
	self justDroppedInto: formerOwner event: evt.
