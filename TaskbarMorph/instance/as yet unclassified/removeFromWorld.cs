removeFromWorld
	"Delete the receiver from its world after restoring minimized tasks.
	Collapse those that were minimized after removal.
	Turn window animation off for the duration."

	|mins animation|
	mins := self tasks select: [:t | t isMinimized].
	animation := Preferences windowAnimation.
	animation ifTrue: [Preferences setPreference: #windowAnimation toValue: false].
	[mins do: [:t | t morph restore; resetCollapsedFrame].
	self delete.
	mins do: [:t | t morph minimize]]
		ensure: [animation ifTrue: [Preferences setPreference: #windowAnimation toValue: true]]