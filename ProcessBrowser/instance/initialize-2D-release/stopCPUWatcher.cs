stopCPUWatcher
	| pw |
	pw _ Smalltalk at: #CPUWatcher ifAbsent: [ ^self ].
	pw ifNotNil: [
		pw stopMonitoring.
		self updateProcessList.
		startedCPUWatcher _ false.	"so a manual restart won't be killed later"
	]
