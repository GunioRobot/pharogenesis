minHeight
	"Return the minimum height for this morph."

	| minH spaceNeeded |
	vResizing = #rigid ifTrue: [^ self fullBounds height].
	submorphs isEmpty ifTrue: [^ self minHeightWhenEmpty].
	orientation == #horizontal ifTrue:
		[minH _ 0.
		submorphs do: [:m | minH _ minH max: m minHeight].
		spaceNeeded _ minH + (2 * (inset + borderWidth))].
	orientation == #vertical ifTrue:
		[spaceNeeded _ 2 * (inset + borderWidth).
		submorphs do: [:m | spaceNeeded _ spaceNeeded + (m minHeight max: minCellSize)]].
	orientation == #free ifTrue:
		[minH _ 0.
		submorphs do: [:m | minH _ minH max: m bounds bottom.
		spaceNeeded _ minH + (2 * inset)]].

	^ spaceNeeded
