shiftSubmorphsBy: delta
	self shiftSubmorphsOtherThan: (submorphs select: [:m | (m hasProperty: #flap) or: [m isKindOf: FlapTab]]) by: delta