stopMonitoring
	"CPUWatcher stopMonitoring"

	CurrentCPUWatcher ifNotNil: [ CurrentCPUWatcher stopMonitoring. ].
	CurrentCPUWatcher _ nil.
