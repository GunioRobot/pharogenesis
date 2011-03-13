nextActiveController
	"Answer the controller that would like control.  
	If there was a click outside the active window, it's the top window
	that now has the mouse, otherwise it's just the top window."

	(newTopClicked notNil and: [newTopClicked])
		ifTrue: [newTopClicked := false.
				^ scheduledControllers 
					detect: [:aController | aController isControlWanted]
					ifNone: [scheduledControllers first]]
		ifFalse: [^ scheduledControllers first]