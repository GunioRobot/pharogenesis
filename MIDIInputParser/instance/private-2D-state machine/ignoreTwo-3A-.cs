ignoreTwo: cmdByte
	"Ignore a two argument command."	

	lastCmdByte _ cmdByte.
	lastSelector _ #ignoreTwo:.
	state _ #ignore2.
