setRuns: newRuns setValues: newValues
	lastIndex _ nil.  "flush access cache"
	runs _ newRuns asArray.
	values _ newValues asArray.