loopOnPort: portNumber loggingTo: fileName
	"Loop forever handling HTTP requests. Run backup jobs periodically."

	| secondsBetweenBackups nextBackupTime socket logEntry |
	secondsBetweenBackups _ 1 * (60 * 60).
	nextBackupTime _ Time totalSeconds + secondsBetweenBackups.
	[true] whileTrue: [
		socket _ ServerPort getConnectionOrNil.
		socket notNil
			ifTrue: [
				logEntry _ self serve: socket.
				ServerLog nextPutAll: logEntry; cr]
			ifFalse: [
				Time totalSeconds > nextBackupTime
					ifTrue: [  "time to back up!"
						logEntry _ self doBackupJobs.
						ServerLog nextPutAll: logEntry; cr.
						nextBackupTime _ Time totalSeconds + secondsBetweenBackups]
					ifFalse: [
						(Delay forMilliseconds: 100) wait]]].
