initialize

	super initialize.
	self label: ''.
	self borderWidth: 2.
	bounds _ 0@0 corner: 16@16.
	offColor _ Color gray.
	onColor _ Color gray.
	switchState _ false.
	oldSwitchState _ false.
	disabled _ false.
	self useSquareCorners
	