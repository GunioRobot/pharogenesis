direction
	^direction ifNil:[direction _ (target - (self getPositionVector)) safelyNormalize].