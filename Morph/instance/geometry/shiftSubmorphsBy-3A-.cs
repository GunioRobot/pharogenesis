shiftSubmorphsBy: delta
	self shiftSubmorphsOtherThan: (submorphs select: [:m | m isFlapOrTab]) by: delta