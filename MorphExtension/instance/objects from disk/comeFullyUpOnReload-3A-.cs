comeFullyUpOnReload: smartRefStream
	"inst vars have default booplean values."

	locked ifNil: [locked := false].
	visible ifNil: [visible := true].
	sticky ifNil: [sticky := false].
	isPartsDonor ifNil: [isPartsDonor := false].
	^ self