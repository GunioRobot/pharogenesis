updateFrom7012
	"self new updateFrom7012"
	"
	Change Set:		nihongo7ModalWindows
	Date:			22 July 2005
	Author:			Takashi Yamamiya and Kazuhiro Abe

	Make some UI elements modal so that the user don't see multiple project saving dialog, etc.
	-------------
	Change Set:		nihongo7BitBlt
	Date:			22 July 2005
	Author:			Yoshiki Ohshima

	Prevents simple crash with errorneous numbers in geometory.
	-----------
	Change Set:		nihongo7WatchersAndReadouts
	Date:			22 July 2005
	Author:			Takashi Yamamiya and Yoshiki Ohshima

	The proposed improvement for watchers and readouts. The areas are:

	* Simple watcher bahves better with Alt-Click.
	* Allows type-in of non-ascii number strings.
	* Should handle ok with translated symbols in symbol tiles.
	----------------
	Change Set:		nihongo7SimpleButtons
	Date:			22 July 2005
	Author:			Takashi Yamamiya

	Hide more buttons in the nav-bar.  Controlled by a preference called 	showAdvancedNavigatorButtons.
	----------------
	Change Set:		ExtNamesStay-tk
	Date:			27 July 2005
	Author:			Ted Kaehler

	When an object is being brought in from a saved project, if its name is already in use, 
	make a new unique internal name (as before).  Set the external name in the costume to its 
	old name.  Internal name is the key for it in References.
	----------------
	Change Set:		SketchFix
	Date:			28 July 2005
	Author:			Andreas Raab

	Restore two missing methods from SketchMorph.
	---------------
	Change Set:		undo-kedama
	Date:			17 March 2006
	Author:			Michael Rueger

	Undoes two squeakland changes that broke etoys
	-----------
	Change Set:		polygonFix-tak	
	Date:			10 February 2006
	Author:			Takashi Yamamiya

	Fixes a bug in generic handling of cached morph state, which manifested itself in a variety
	 of ways involving PolygonMorphs, such as the fact that a drop of a Star always required \
	a second click. 

	Reverts Morph>>releaseCachedState so that it no longer resets formerOwner, formerPosition, 
	and undoGrabCommand, thus making #releaseCachedState once again safe to call while 
	drag is  underway, The resetting of formerOwner, etc. is moved to #prepareToBeSaved
	----------
	0003295: In 7006 MorphicMenuItem>>keystroke: code versions reveal a conflict.
	"
	self script50.
	self flushCaches.
	MCDefinition clearInstances.