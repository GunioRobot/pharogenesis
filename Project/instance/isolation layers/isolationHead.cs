isolationHead
	"Go up the parent chain and find the nearest isolated project."

	isolatedHead == true ifTrue: [^ self].
	self isTopProject ifTrue: [^ nil].
	^ parentProject isolationHead