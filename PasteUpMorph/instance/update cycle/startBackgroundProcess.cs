startBackgroundProcess
	"Start a process to update this world in the background. Return the process created."

	| p |
	p _ [[true] whileTrue: [
		self doOneCycleInBackground.
		(Delay forMilliseconds: 20) wait]] newProcess.
	p resume.
	^ p
