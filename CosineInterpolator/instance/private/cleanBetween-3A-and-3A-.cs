cleanBetween: start and: end
	self points: (self points reject: [ :each | each key between: start and: end])