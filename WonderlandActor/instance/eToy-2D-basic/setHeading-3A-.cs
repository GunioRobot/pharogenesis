setHeading: heading
	self setPointOfView: ((self getPointOfView) at: 5 put: heading negated; yourself) duration: rightNow.