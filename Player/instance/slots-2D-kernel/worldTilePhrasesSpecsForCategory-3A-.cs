worldTilePhrasesSpecsForCategory: aCategory
	"Return an array of slot and script names and info for use in a viewer on the receiver, in the situation where the receiver's costume is the World.   Categories 'instance variables' and 'scripts'  will already have been taken care of and need not be dealt with here."

	| aList categoryString |
	categoryString _ aCategory asString.
	aList _ #().

	(categoryString = 'basic') ifTrue:
		[aList _ #((script beep:) (script doMenuItem:))].

	(categoryString = 'color & border') ifTrue:
		[aList _ #((slot color))].

	(categoryString = 'miscellaneous') ifTrue:
		[aList _ #((script startScript:) (script stopScript:) (script pauseScript:))].

	(categoryString = 'pen trails') ifTrue:
		[aList _ #((script liftAllPens) (script lowerAllPens) (script clearTurtleTrails))].

	(categoryString = 'playfield') ifTrue:
		[aList _ #((script initiatePainting) (slot cursor) (slot valueAtCursor) (slot mouseX) (slot mouseY)(script roundUpStrays) (script unhideHiddenObjects))].

	^ aList collect: [:aPair | self phraseSpecFor: aPair]

