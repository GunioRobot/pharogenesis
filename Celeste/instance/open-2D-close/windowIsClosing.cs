windowIsClosing
	"Synchronize the mail database when my window is closed.  Don't close it completely, because there may be other users of the same DB"

	self synchronizeToDisk.
