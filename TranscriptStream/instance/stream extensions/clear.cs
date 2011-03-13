clear
	"Clear all characters and redisplay the view."
	
	self changed: #clearText.
	"clear the buffer entirely since it may become quite large and hang around"
	self on: (String new: 1000)