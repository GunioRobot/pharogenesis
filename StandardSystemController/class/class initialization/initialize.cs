initialize
	"Set up the menus for standard windows.  
	 6/6/96 sw: added fullScreen"

	self flag: #noteToDan.   "
1.  note that I added a fullScreen command.
2.  the old macPaint command appears to be broken.  We should presumably fix it or discard it.
3.  the frame command seems no longer to allow you to reframe an open window, and of course its functionality has now been overtaken by the drag-corners stuff.
4.  move and label and collapse and close are all redundant with title-bar controls.

With the above in mind, I've for the moment removed macPaint and frame, but kept the four redundant commands to use in those cases where owing to some bug you can't see a window's title bar.  

6/10/96 sw"

	ScheduledBlueButtonMenu _ PopUpMenu labels: 'label
color...
move
full screen
collapse
close' 

"frame 
macPaint"

	lines: #(2).  "6"

	ScheduledBlueButtonMessages _ #(label chooseColor move "expand" fullScreen collapse close "macPaint")

	"StandardSystemController initialize.
	ScheduledControllers scheduledControllers
		do: [:c | (c isKindOf: ScreenController)
			ifFalse: [c initializeBlueButtonMenu]]"