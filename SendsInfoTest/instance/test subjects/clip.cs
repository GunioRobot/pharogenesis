clip	
	"This method is never run. It is here just so that the sends in it can be
	tallied by the SendInfo interpreter."
	| temp |
	self printString.
	temp _ self.
	temp error: 4 + 5