hasHalo: aBool
	super hasHalo: aBool.
	aBool ifFalse:[
		(self hasProperty: #surviveHaloLoss) ifFalse:[
			"Need to get rid of wrappers on top of us, so..."
			owner ifNotNil:[owner hasHalo: owner hasHalo].
			self delete].
		self removeProperty: #surviveHaloLoss].
