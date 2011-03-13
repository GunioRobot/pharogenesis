restartWorldCycleWithEvent: evt

	"redispatch that click in outer world"

	pendingEvent _ evt.
	Project spawnNewProcessAndTerminateOld: true
