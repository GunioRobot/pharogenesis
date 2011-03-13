example
	"Continually prints two lines of text wherever you point with the cursor 
	and press any mouse button.  Terminate by pressing any key on the 
	keyboard."

	| t |
	t _ 'this is a line of characters and
this is the second line.' asDisplayText.
	t alignTo: #center.
	[Sensor anyButtonPressed]
		whileFalse:
			[t displayOn: Display at: Sensor cursorPoint]

	"DisplayText example."