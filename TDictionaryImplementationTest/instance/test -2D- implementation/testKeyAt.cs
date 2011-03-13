testKeyAt
	self assert: (self nonEmptyDict keyAt: 1) == #b.
	self assert: (self nonEmptyDict keyAt: 2) == #c.
	self assert: (self nonEmptyDict keyAt: 3) == #d.
