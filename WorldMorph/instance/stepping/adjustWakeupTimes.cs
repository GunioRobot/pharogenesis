adjustWakeupTimes
	"Fix the wakeup times in my step list. This is necessary when this world has been restarted after a pause, say because some other view had control, after a snapshot, or because the millisecond clock has wrapped around. (The latter is a rare occurence with a 32-bit clock!)"

	| earliestTime t now m oldWakeupTime |
	"find earliest wakeup time"
	earliestTime _ SmallInteger maxVal.
	stepList do: [:entry |
		t _ entry at: 2.
		t < earliestTime ifTrue: [earliestTime _ t]].

	"recompute all wakeup times, using earliestTime as the origin"
	now _ Time millisecondClockValue.
	stepList do: [:entry |
		m _ entry at: 1.
		oldWakeupTime _ entry at: 2.
		entry at: 2 put: now + ((oldWakeupTime - earliestTime) min: m stepTime)].
	lastStepTime _ now.
