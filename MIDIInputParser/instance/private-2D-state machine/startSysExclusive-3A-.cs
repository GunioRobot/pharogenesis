startSysExclusive: cmdByte
	"The beginning of a variable length 'system exclusive' command."

	sysExBuffer resetContents.
	lastCmdByte _ nil.  "system exclusive commands clear running status"
	lastSelector _ nil.
	state _ #sysExclusive.
