direction
	^direction ifNil:[direction _ (target - position) safelyNormalize].