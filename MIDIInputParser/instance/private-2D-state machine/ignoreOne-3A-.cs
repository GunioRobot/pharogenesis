ignoreOne: cmdByte
	"Ignore a one argument command."	

	lastCmdByte _ cmdByte.
	lastSelector _ #ignoreOne:.
	state _ #ignore1.
