additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #(
		(#basic (
			(slot x 'The x coordinate' number readWrite player getX player setX:)
			(slot y  	'The y coordinate' number readWrite	player 	getY player setY:)
			(slot heading  'Which direction the object is facing.  0 is straight up' number readWrite player getHeading player setHeading:)
			(command forward: 'Moves the object forward in the direction it is heading' number)
			(command turn: 'Change the heading of the object by the specified amount' number)
			(command beep: 'Make the specified sound' sound)))

		"note: if you change the thing below you also need to change #tileScriptCommands."
		(#scripts (
			(command emptyScript 'an empty script'))
		)
		(#'color & border' (
			(slot color 'The color of the object' color readWrite player getColor  player  setColor:)
			(slot colorUnder 'The color under the center of the object' color readOnly player getColorUnder unused  unused )
			(slot luminanceUnder 'The luminance under the center of the object' number readOnly player getLuminanceUnder unused unused)
			(slot saturationUnder 'The saturation under the center of the object' number readOnly player getSaturationUnder unused unused)
			(slot brightnessUnder 'The brightness under the center of the object' number readOnly player getBrightnessUnder unused unused)
			(slot borderColor 'The color of the object''s border' color readWrite player getBorderColor player  setBorderColor:)
			(slot borderWidth 'The width of the object''s border' number readWrite player getBorderWidth player setBorderWidth:)
			(slot roundedCorners 'Whether corners should be rounded' boolean readWrite player getRoundedCorners player setRoundedCorners:)))

		(geometry (
			(slot  scaleFactor 'Yeah, the scale factor' number readWrite player getScaleFactor player setScaleFactor:)
			(slot  left   'The left edge, yeah' number readWrite player getLeft  player  setLeft:)
			(slot right  'The right edge, yeah' number readWrite player getRight  player  setRight:)
			(slot  top  'The top edge' number readWrite player getTop  player  setTop:) 
			(slot  bottom  'The bottom edge' number readWrite player getBottom  player  setBottom:) 
			(slot  width  'The width' number readWrite player getWidth  player  setWidth:)
			(slot  height  'The height' number readWrite player getHeight  player  setHeight:) 
			(slot x   'The x coordinate' number readWrite player  getX   player setX:)
			(slot y   'The y coordinate' number readWrite player  getY  player setY:)
			(slot heading  'Which direction the object is facing.  0 is straight up' number readWrite player getHeading  player setHeading:)))

		(miscellaneous (
			(command doMenuItem: 'do the menu item' menu) 
			(command show 'show the guy')
			(command hide 'hide the guy')
			(command wearCostumeOf: 'wear the costume of...' player)
			(command startScript: 'start the given script ticking' string)
			(command stopScript: 'make the given script be "normal"' string)
			(command pauseScript: 'make the given script be "paused"' string)
			(command tellAllSiblings: 'send a message to all siblings' string)
			(slot copy 'returns a copy of this object' player readOnly player getNewClone	 unused unused)
			(slot elementNumber 'my index in my container' number readWrite player getIndexInOwner player setIndexInOwner:)))

		(motion (
			(slot x 'The x coordinate' number readWrite player getX player setX:)
			(slot y  	'The y coordinate' number readWrite	player 	getY player setY:)
			(slot heading  'Which direction the object is facing.  0 is straight up' number readWrite player getHeading player setHeading:)
			(command forward: 'Moves the object forward in the direction it is heading' number)
			(slot obtrudes 'whether the object sticks out over its container''s edge' boolean readOnly player getObtrudes unused unused) 
			(command moveToward: 'move toward the given object' player) 
			(command turn: 'Change the heading of the object by the specified amount' number)
			(command bounce: 'bounce off the edge if hit' sound) 
			(command wrap 'wrap off the edge if appropriate') 
			(command followPath 'follow the yellow brick road') 
			(command goToRightOf: 'place this object to the right of another' player)))

		(#'pen use' (
			(slot penColor 'the color of ink used by the pen' color readWrite player getPenColor player setPenColor:) 
			(slot penSize 'the width of the pen' number readWrite player getPenSize player setPenSize:) 
			(slot penDown 'whether the pen is currently down' boolean readWrite player getPenDown player setPenDown:)))

		(#tests (
			(slot isOverColor 'whether any part of the object is over the given color' boolean	readOnly player seesColor: unused unused) 
			(slot isUnderMouse 'whether the object is under the current mouse position' boolean readOnly	player getIsUnderMouse unused unused)
			(slot colorSees	'whether the given color sees the given color' boolean readOnly	player color:sees:	unused	unused)
			(slot touchesA	'whether I touch something that looks like...' boolean readOnly player touchesA:	unused	unused)
			(slot obtrudes 'whether the object sticks out over its container''s edge' boolean readOnly player getObtrudes unused unused))))