paneForWantsRolloverToggle

	^self inARow: {
		self
			directToggleButtonFor: self 
			getter: #targetWantsRollover
			setter: #toggleTargetWantsRollover
			help: 'Turn mouse-over highlighting on or off' translated.
		self lockedString: ' Mouse-over highlighting' translated.
	}
