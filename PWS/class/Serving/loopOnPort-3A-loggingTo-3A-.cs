loopOnPort: portNumber loggingTo: fileName
	"This is the inner HTTP server loop. Periodically flush the logfile. Invoke nightly jobs."

	| port connection log clock |
	Socket initializeNetwork: 0.
	log := FileStream fileNamed: fileName. log position: log size.
	(port := ServerSocket new) bindTo: portNumber backlog: 8.
	clock := Time now hours.
	ServerStatus := #running.
	[	(connection := port listen) notNil
		ifTrue: [ log reopenGently. log nextPutAll: (self serve: connection); cr ]
		ifFalse: [
			clock ~= Time now hours ifTrue: [
				log reopenGently. log nextPutAll: (self doBackupJobs); cr.
				clock := Time now hours.
				"ServerStatus := #snapshot" "no snapshot" ].
			"log flush.  log position: log size."].
		ServerStatus = #running ] whileTrue.
	port destroy.
	log reopenGently.  log close
