recordTwo: cmdByte
	"Record a two argument command at the current time."	

	lastCmdByte _ cmdByte.
	lastSelector _ #recordTwo:.
	state _ #want1of2.
