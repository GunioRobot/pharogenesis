comeFullyUpOnReload: smartRefStream
	"inst vars have default booplean values."

	locked ifNil: [locked _ false].
	visible ifNil: [visible _ true].
	sticky ifNil: [sticky _ false].
	isPartsDonor ifNil: [isPartsDonor _ false].
	^ self