adaptToWorld
	| wasShowing new |
	(wasShowing _ self flapShowing) ifTrue:
					[self hideFlap].
	(self respondsTo: #unhibernate) ifTrue: [
		(new _ self unhibernate) == self ifFalse: [
			^ new adaptToWorld]].
	self spanWorld.
	self positionObject: self.
	wasShowing ifTrue:
		[self showFlap]