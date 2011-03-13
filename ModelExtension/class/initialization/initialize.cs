initialize
	self isAbstract not ifTrue:
		[self current: self new]