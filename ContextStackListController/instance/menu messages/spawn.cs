spawn
	"Create and schedule a message browser for the code of the model's 
	selected message. Retain any edits that have not yet been accepted."

	self controlTerminate.
	model spawn.
	self controlInitialize