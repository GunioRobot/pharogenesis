unschedule
	"Unschedule this Delay. Do nothing if it wasn't scheduled."

	| done |
	TimerEventLoop ifNotNil:[^self unscheduleEvent].
	AccessProtect critical: [
		done := false.
		[done] whileFalse:
			[SuspendedDelays remove: self ifAbsent: [done := true]].
		ActiveDelay == self ifTrue: [
			SuspendedDelays isEmpty
				ifTrue: [
					ActiveDelay := nil.
					ActiveDelayStartTime := nil]
				ifFalse: [
					SuspendedDelays removeFirst activate]]].
