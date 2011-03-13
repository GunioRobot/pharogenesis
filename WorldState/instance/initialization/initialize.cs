initialize

	hands _ Array new.
	damageRecorder_ DamageRecorder new.
	stepList _ Heap sortBlock: self stepListSortBlock.
	lastStepTime _ 0.
	lastAlarmTime _ 0.