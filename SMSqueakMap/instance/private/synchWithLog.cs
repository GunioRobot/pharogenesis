synchWithLog
	"Synchronize myself with the current logfile.
	If the logfile has newer updates, load them.
	If the logfile can not produce updates as far back as I need, do a full reload.
	If the logfile does not exist or if I have newer updates than the logfile,
	create a new logfile from me.

	The end result is that I am in synch with the logfile and we are both as
	updated as possible."

	| updates |
	 "If there is no logfile, create it from ourself."
	(self isLogFileAvailable) ifFalse: [self saveNewLog. ^self].
	updates _ self updatesSinceTransactionInLog: transactionCounter.
	updates = '' ifTrue: [^self]. "Already in synch."
	updates = 'DO FULL!'
		ifFalse: [
			updates = 'STALE SERVER!'
				ifTrue: [self saveNewLog]
				ifFalse: [self loadUpdatesFrom: (ReadStream on: updates) log: false]]
		ifTrue: [self reloadLog]