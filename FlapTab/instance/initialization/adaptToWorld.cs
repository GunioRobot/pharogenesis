adaptToWorld
	| wasShowing new |
	(wasShowing := self flapShowing) ifTrue:
					[self hideFlap].
	(self respondsTo: #unhibernate) ifTrue: [
		(new := self unhibernate) == self ifFalse: [
			^ new adaptToWorld]].
	self spanWorld.
	self positionObject: self.
	wasShowing ifTrue:
		[self showFlap]