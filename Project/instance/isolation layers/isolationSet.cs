isolationSet

	"Return the changeSet for this isolation layer or nil"
	isolatedHead == true ifTrue: [^ changeSet].
	self isTopProject ifTrue: [^ nil].  "At the top, but not isolated"
	^ parentProject isolationSet

