accept

	model isUnlocked ifTrue: [^view flash].
	self controlTerminate.
	(model contents: paragraph text notifying: self) ifTrue: [super accept].
	self controlInitialize