changed
	"Quicker to invalidate handles individually if target is large (especially the world)"

	self extent > (200@200)
		ifTrue: [self submorphsDo: [:m | m changed]]
		ifFalse: [super changed].
