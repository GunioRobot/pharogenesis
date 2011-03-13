catchThePig: aProcess
	| rules |
	"nickname, allow-stop, allow-debug"
	rules := ProcessBrowser nameAndRulesFor: aProcess.

	(ProcessBrowser isUIProcess: aProcess)
		ifTrue: [ "aProcess debugWithTitle: 'Interrupted from the CPUWatcher'." ]
		ifFalse: [ rules second ifFalse: [ ^self ].
				ProcessBrowser suspendProcess: aProcess.
				self openWindowForSuspendedProcess: aProcess ]
