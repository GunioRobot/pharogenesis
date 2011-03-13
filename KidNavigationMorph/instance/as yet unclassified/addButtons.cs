addButtons

	(self addARow: {

		self inAColumn: {self buttonFind}.
		self transparentSpacerOfSize:6@6.
		self transparentSpacerOfSize:6@6.
		self inAColumn: {self buttonNewProject}.
	}) layoutInset: 6.
	self addARow: {
		self transparentSpacerOfSize:0@6.
	}.
	(self addARow: {
		self inAColumn: {self buttonPublish}.
	}) layoutInset: 6.
	self addARow: {
		self transparentSpacerOfSize:0@18.
	}.
	(self addARow: {
		self inAColumn: {self buttonQuit}.
	}) layoutInset: 6.

