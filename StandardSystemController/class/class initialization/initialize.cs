initialize   "StandardSystemController initialize"
	"Set up the menus for standard windows.  
	 6/6/96 sw: added fullScreen"

	ScheduledBlueButtonMenu _ PopUpMenu labels: 'edit label
choose color...
two-tone/full color
move
frame
full screen
collapse
close'
	lines: #(3 7).
	ScheduledBlueButtonMessages _ #(label chooseColor toggleTwoTone move reframe fullScreen collapse close).
"
StandardSystemController initialize.
ScheduledControllers scheduledWindowControllers
		do: [:c | c initializeBlueButtonMenu]
"
	VBorderCursor _ Cursor extent: 16@16 fromArray: #(
		2r1010000000000000
		2r1010000000000000
		2r1010000000000000
		2r1010000000000000
		2r1010000000000000
		2r1010010000100000
		2r1010110000110000
		2r1011111111111000
		2r1010110000110000
		2r1010010000100000
		2r1010000000000000
		2r1010000000000000
		2r1010000000000000
		2r1010000000000000
		2r1010000000000000
		2r1010000000000000)
			offset: 0@0.
	HBorderCursor _ Cursor extent: 16@16 fromArray: #(
		2r1111111111111111
		2r0000000000000000
		2r1111111111111111
		2r0000000100000000
		2r0000001110000000
		2r0000011111000000
		2r0000000100000000
		2r0000000100000000
		2r0000000100000000
		2r0000000100000000
		2r0000011111000000
		2r0000001110000000
		2r0000000100000000
		2r0000000000000000
		2r0000000000000000
		2r0000000000000000)
			offset: 0@0.