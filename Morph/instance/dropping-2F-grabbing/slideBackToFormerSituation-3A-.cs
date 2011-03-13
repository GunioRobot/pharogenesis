slideBackToFormerSituation: evt

	| slideForm formerOwner formerPosition aWorld startPoint endPoint trans |
	formerOwner _ self formerOwner.
	formerPosition _ self formerPosition.
	aWorld _ self world.

	trans _ formerOwner transformFromWorld.
	trans isPureTranslation 
		ifTrue: [slideForm _ self imageForm offset: 0@0]
		ifFalse: [slideForm _ ((TransformationMorph new asFlexOf: self) transform: trans)
								imageForm offset: 0@0].

	startPoint _ evt hand fullBounds origin.
	endPoint _ trans localPointToGlobal: formerPosition.
	owner privateRemoveMorph: self.
	aWorld displayWorld.
	slideForm slideFrom: startPoint to: endPoint nSteps: 12 delay: 15.
	formerOwner addMorph: self.
	self position: formerPosition.
	self justDroppedInto: formerOwner event: evt.
