createDB
	"Create a new mail database."


	self openDB.							"creates new DB files"
	"gg: adding base categories:"
	self addCategory:'new'; addCategory:'.tosend.'.
	
	self saveDB.							"save the new mail database to disk"