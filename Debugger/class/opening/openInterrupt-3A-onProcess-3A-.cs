openInterrupt: aString onProcess: interruptedProcess
	"Open a notifier in response to an interrupt. An interrupt occurs when the user types the interrupt key (cmd-. on Macs, ctrl-c or alt-. on other systems) or when the low-space watcher detects that memory is low."
	| debugger |
	<primitive: 19> "Simulation guard"
	debugger _ self new.
	debugger
		process: interruptedProcess
		controller: ((Smalltalk isMorphic not
					and: [ScheduledControllers activeControllerProcess == interruptedProcess])
						ifTrue: [ScheduledControllers activeController])
		context: interruptedProcess suspendedContext.
	debugger externalInterrupt: true.

Preferences logDebuggerStackToFile ifTrue:
	[(aString includesSubString: 'Space') & 
		(aString includesSubString: 'low') ifTrue: [
			Smalltalk logError: aString inContext: debugger interruptedContext to:'LowSpaceDebug.log']].
	Preferences eToyFriendly ifTrue: [World stopRunningAll].
	^ debugger
		openNotifierContents: nil
		label: aString
