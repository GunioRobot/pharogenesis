initialize
	super initialize.
	self on: #mouseMove send: #mouseStillDown:onItem: to: self