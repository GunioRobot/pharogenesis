helpContributions
	"Answer a list of pairs of the form (<symbol> <help message> ) to contribute to the system help dictionary"
	
"NB: Many of the items here are not needed any more since they're specified as part of command definitions now.  Someone needs to take the time to go through the list and remove items no longer needed.  But who's got that kind of time?"

	^ #(
		(acceptScript:for:
			'submit the contents of the given script editor as the code defining the given selector')
		(actorState
			'return the ActorState object for the receiver, creating it if necessary')
		(addInstanceVariable
			'start the interaction for adding a new variable to the object')
		(addPlayerMenuItemsTo:hand:
			'add player-specific menu items to the given menu, on behalf of the given hand.  At present, these are only commands relating to the turtle')
		(addYesNoToHand
			'Press here to tear off a  TEST/YES/NO unit which you can drop into your script')
		(allScriptEditors
			'answer a list off the extant ScriptEditors for the receiver')
		(amount
			'The amount of displacement')
		(angle	
			'The angular displacement')
		(anonymousScriptEditorFor:
			'answer a new ScriptEditor object to serve as the place for scripting an anonymous (unnamed, unsaved) script for the receiver')
		(append:
			'add an object to this container')
		(prepend:
			'add an object to this container')
		(assignDecrGetter:setter:amt:
			'evaluate the decrement variant of assignment')
		(assignGetter:setter:amt:
			'evaluate the vanilla variant of assignment')
		(assignIncrGetter:setter:amt:
			'evalute the increment version of assignment')
		(assignMultGetter:setter:amt:
			'evaluate the multiplicative version of assignment')
		(assureEventHandlerRepresentsStatus
			'make certain that the event handler associated with my current costume is set up to conform to my current script-status')
		(assureExternalName
			'If I do not currently have an external name assigned, get one now')
		(assureUniClass
			'make certain that I am a member a uniclass (i.e. a unique subclass); if I am not, create one now and become me into an instance of it')
		(availableCostumeNames
			'answer a list of strings representing the names of all costumes currently available for me')
		(availableCostumesForArrows
			'answer a list of actual, instantiated costumes for me, which can be cycled through as the user hits a next-costume or previous-costume button in a viewer')
		(beep:
			'make the specified sound')
		(borderColor
			'The color of the object''s border')
		(borderWidth
			'The width of the object''s border')
		(bottom
			'My bottom edge, measured downward from the top edge of the world')
		(bounce:
			'If object strayed beyond the boundaries of its container, make it reflect back into it, making the specified noise while doing so.')
		(bounce
			'If object strayed beyond the boundaries of its container, make it reflect back into it')
		(chooseTrigger
'When this script should run.
"normal" means "only when called"')
		(clearTurtleTrails
			'Clear all the pen trails in the interior.')
		(clearOwnersPenTrails
			'Clear all the pen trails in my container.')
		(color	
			'The object''s interior color')
		(colorSees
			'Whether a given color in the object is over another given color')
		(colorUnder
			'The color under the center of the object')
		(copy
			'Return a new object that is very much like this one')
		(cursor	
			'The index of the chosen element')
		(deleteCard
			'Delete the current card.')
		(dismiss
			'Click here to dismiss me')
		(doMenuItem:
			'Do a menu item, the same way as if it were chosen manually')
		(doScript:
			'Perform the given script once, on the next tick.')
		(elementNumber
			'My element number as seen by my owner')
		(fire
			'Run any and all button-firing scripts of this object')
		(firstPage
			'Go to first page of book')
		(followPath
				'Retrace the path the object has memorized, if any.')
		(forward:
			'Moves the object forward in the direction it is heading') 
		(goto:
			'Go to the specfied book page')
		(goToNextCardInStack
			'Go to the next card')
		(goToPreviousCardInStack
			'Go to the previous card.')
		(goToRightOf:
			'Align the object just to the right of any specified object.')
		(heading
			'Which direction the object is facing.  0 is straight up') 
		(height	
			'The distance between the top and bottom edges of the object')
		(hide
			'Make the object so that it does not display and cannot handle input')
		(initiatePainting	
			'Initiate painting of a new object in the standard playfield.')
		(initiatePaintingIn:
			'Initiate painting of a new object in the given place.')
		(isOverColor
			'Whether any part of this object is directly over the specified color')
		(isUnderMouse
			'Whether any part of this object is beneath the current mouse-cursor position')
		(lastPage
			'Go to the last page of the book.')
		(left
			'My left edge, measured from the left edge of the World')
		(leftRight
			'The horizontal displacement')
		(liftAllPens
			'Lift the pens on all the objects in my interior.')
		(lowerAllPens
			'Lower the pens on all the objects in my interior.')
		(mouseX
			'The x coordinate of the mouse pointer')
		(mouseY
			'The y coordinate of the mouse pointer')
		(moveToward:
			'Move in the direction of another object.')
		(insertCard
			'Create a new card.')
		(nextPage
			'Go to next page.')
		(numberAtCursor
			'The number held by the object at the chosen element')
		(objectNameInHalo
			'Object''s name -- To change: click here, edit, hit ENTER')
		(obtrudes
			'Whether any part of the object sticks out beyond its container''s borders')
		(offerScriptorMenu
			'The Scriptee.
Press here to get a menu')
		(pauseScript:
			'Make a running script become paused.')
		(penDown
			'Whether the object''s pen is down (true) or up (false)')
		(penColor
			'The color of the object''s pen')
		(penSize	
			'The size of the object''s pen')
		(clearPenTrails
			'Clear all pen trails in the current playfield')
		(playerSeeingColorPhrase
			'The player who "sees" a given color')
		(previousPage
			'Go to previous page')

		(show
			'If object was hidden, make it show itself again.')
		(startScript:
			'Make a script start running.')
		(stopScript:
			'Make a script stop running.')
		(top
			'My top edge, measured downward from the top edge of the world')
		(right
			'My right edge, measured from the left edge of the world')
		(roundUpStrays
			'Bring all out-of-container subparts back into view.')
		(scaleFactor
			'The amount by which the object is scaled')
		(stopScript:
			'make the specified script stop running')
		(tellAllSiblings:
			'send a message to all of my sibling instances')
		(try
			'Run this command once.')
		(tryMe
			'Click here to run this script once; hold button down to run repeatedly')
		(turn:				
			'Change the heading of the object by the specified amount')
		(unhideHiddenObjects
			'Unhide all hidden objects.')
		(upDown
			'The vertical displacement')
		(userScript
			'This is a script defined by you.')
		(userSlot
			'This is a variable defined by you.  Click here to change its type')
		(valueAtCursor
			'The chosen element')
		(wearCostumeOf:
			'Wear the same kind of costume as the other object')
		(width	
			'The distance between the left and right edges of the object')
		(wrap
			'If object has strayed beond the boundaries of its container, make it reappear from the opposite edge.')
		(x
			'The x coordinate, measured from the left of the container')
		(y
			'The y-coordinate, measured upward from the bottom of the container')

		)
