unschedule
	"Unschedule this Delay. Do nothing if it wasn't scheduled."

	| done |
	AccessProtect critical: [
		done _ false.
		[done] whileFalse:
			[SuspendedDelays remove: self ifAbsent: [done _ true]].
		ActiveDelay == self ifTrue: [
			SuspendedDelays isEmpty
				ifTrue: [
					ActiveDelay _ nil.
					ActiveDelayStartTime _ nil]
				ifFalse: [
					SuspendedDelays removeFirst activate]]].
