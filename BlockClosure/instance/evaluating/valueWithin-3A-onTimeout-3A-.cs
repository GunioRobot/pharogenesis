valueWithin: aDuration onTimeout: timeoutBlock
	"Evaluate the receiver.
	If the evaluation does not complete in less than aDuration evaluate the timeoutBlock instead"

	| theProcess delay watchdog done result |

	aDuration <= Duration zero ifTrue: [^ timeoutBlock value ].

	"the block will be executed in the current process"
	theProcess := Processor activeProcess.
	delay := aDuration asDelay.

	"make a watchdog process"
	watchdog := [
		delay wait. 	"wait for timeout or completion"
		done ifFalse: [ theProcess signalException: TimedOut ] 
	] newProcess.

	"watchdog needs to run at high priority to do its job"
	watchdog priority: Processor timingPriority.

	"catch the timeout signal"
	^ [	done := false.
		watchdog resume.				"start up the watchdog"
		result := self value.				"evaluate the receiver"
		done := true.						"it has completed, so ..."
		delay delaySemaphore signal.	"arrange for the watchdog to exit"
		result ]
			on: TimedOut do: [ :e | timeoutBlock value ].
