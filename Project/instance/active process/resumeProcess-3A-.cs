resumeProcess: aProcess
	"Adopt aProcess as the project process -- probably because of proceeding from a debugger"
	activeProcess _ aProcess.
	activeProcess resume