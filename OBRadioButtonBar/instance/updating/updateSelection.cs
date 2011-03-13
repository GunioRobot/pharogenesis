updateSelection
	| oldSelection |
	oldSelection _ selection.
	selection _ self getSelectionIndex.
	self withButtonAt: oldSelection do: [:button | button selectionChanged].
	self withSelectedButtonDo: [:button | button selectionChanged]