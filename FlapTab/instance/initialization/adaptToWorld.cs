adaptToWorld
	| wasShowing |
	(wasShowing _ self flapShowing) ifTrue:
					[self hideFlap].
	self spanWorld.
	self positionObject: self.
	wasShowing ifTrue:
		[self showFlap]