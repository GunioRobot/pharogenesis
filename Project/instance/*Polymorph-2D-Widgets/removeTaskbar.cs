removeTaskbar
	"Remove the receiver's taskbars."
	
	self world taskbars do: [:each | each removeFromWorld]