maxWidth
	"Return the minimum width for this morph."

	| spaceNeeded minW |
	hResizing = #rigid ifTrue: [^ self fullBounds width].
	submorphs isEmpty ifTrue: [^ self minWidthWhenEmpty].
	orientation == #horizontal ifTrue:
		[spaceNeeded _ 2 * (inset + borderWidth).
		submorphs do: [:m | spaceNeeded _ spaceNeeded + (m minWidth max: minCellSize)]].
	orientation == #vertical ifTrue:
		[minW _ 0.
		submorphs do: [:m | minW _ minW max: m minWidth].
		spaceNeeded _ minW + (2 * (inset + borderWidth))].
	orientation == #free ifTrue:
		[spaceNeeded _ 0.
		submorphs do: [:m | spaceNeeded _ spaceNeeded max: m x]].
	^ spaceNeeded