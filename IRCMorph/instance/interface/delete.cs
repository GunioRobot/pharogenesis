delete
	super delete.
	connection quit.
	connection processIO.  "give the QUIT a brief chance to happen"
	connection disconnect.