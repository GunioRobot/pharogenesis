recordOne: cmdByte
	"Record a one argument command at the current time."	

	lastCmdByte _ cmdByte.
	lastSelector _ #recordOne:.
	state _ #want1only.
