initialize

	super initialize.
	self label: ''.
	self borderWidth: 3.
	bounds _ 0@0 corner: 20@20.
	offColor _ self preferredColor.
	onColor _ self preferredColor.
	switchState _ false.
	oldSwitchState _ false.
	disabled _ false.
	isMine _ false.
	nearMines _ 0.
	self useSquareCorners.
	palette _ (Color wheel: 8) asOrderedCollection reverse.
"	flashColor _ palette removeLast."
