run
	"Suspend current process and execute self instead"

	| proc |
	proc _ Processor activeProcess.
	[	proc suspend.
		self resume.
	] forkAt: Processor highestPriority