updateFrom7008
	"self new updateFrom7008"
	"
	Change Set:		kedama2.7-yo
	Date:			9 May 2005
	Author:			Yoshiki Ohshima	
	-------------------------------------------
	Change Set:		flexFix-sw
	Date:			30 March 2005
	Author:			Scott Wallace

	Fix for Mantis bug 993: 'rotating morph changes z-order.'  This is a bug that dates to the 	original implementaiton of 'flexing' (generic Morph rotation) in early 1998.  After this fix, 	when a flex shell is added, we now remember the z-position of the original morph and 	ascribe that same z-position to the TransformationMorph that replaces it.

	This update also fixes the dual of that bug, which is that when a TransformationMorph 	decides it's no longer needed, and gets itself replaced by the morph it formerly had been 	governing, the unrotated morph had not been getting inserted in the z-ordering in the same 	place.	
	---------------------------------------------
	Change Set:		noScritch-sw
	Date:			6 April 2005
	Author:			Scott Wallace

	The Scritch sound is supressed
	----------------------------------------------
	Change Set:		dupFixes-sw
	Date:			19 April 2005
	Author:			Scott Wallace

	When the user chooses 'duplicate' from the halo-actions submenu of the halo menu of a 	rotated object, the result had formerly been an unrotated object that was not known to the 	allExtantPlayers list of the project's presenter, so would not come up ticking, etc.  This 	update fixes those glitches.
	Also:  When you dismiss a morph via its halo, its player gets removed from the project's 	allExtantPlayers list -- an optimization.
	-----------------------------
	Change Set:		selectionSibFix-sw
	Date:			19 April 2005
	Author:			Scott Wallace

	Fix for Mantis bug  981: Making a sibling of SelectionMorph causes error.
	Version 4 of this fileout also fixes bugs involving use of the 'duplicate' feature from the 	'halo actions' submenu of a SelectionMorph -- such duplicates were flawed in a couple of 	way.
	-------------------------------
	Change Set:		tickingPainting-sw
	Date:			30 April 2005
	Author:			Scott Wallace

	Two responses to the concern about ticking-while-painting:

	(1)  Adds the #keepTickingWhilePainting preference; when true, scripts will continue to tick 	while the user is in a painting session.
	(2)  If this new preference is *false*, scripts that had been ticking when painting was 	initiated now resume ticking once painting is done.
	------------
	Change Set:		acceptPlayerTile-sw
	Date:			1 May 2005
	Author:			Scott Wallace

	Implements a short-cut feature requested by Alan (or rather 'remembered' by him ;-) as 	follows:  a player-valued tile can now be dropped onto a graphic-valued pad, whereup it 	expands into appropriate retrieval tiles for obtaining a graphic from the player.
	---------------
	Change Set:		unCustoming-sw
	Date:			17 June 2005
	Author:			Scott Wallace

	When the allowEtoyUserCustomEvents preference is false, refrain from showing the 	triggeringObject item in the Viewer and from offering the CustomEvents type in type-list 	popups.
	Also now makes the allowEtoyUserCustomEvents preference behave like a normal preference, 	i.e. independently of eToyFriendly, but sets it appropriately whenever eToyFriendly is 	changed -- after which it *can* subsequently be changed manually if desired, thus making 	it possible to set things up to operate with eToyFriendly on yet offering those CustomEvents.
	------------------------
	Change Set:		vectorAccess-sw
	Date:			9 July 2005
	Author:			Scott Wallace

	Gives easier access to the command for turning on the vector vocabulary.  Makes it possible 	to set an image up such that the vector vocbulary is always in use by default.  The 	primary access to this control is now via the World's Viewer, which now gets a 	'preferences' category, into which is also put a #dropProducesWatcher control.
	"
	self script47.
	self flushCaches.
	MCDefinition clearInstances.
	
	Preferences addPreference: #useVectorVocabulary categories: #(scripting) default: false  balloonHelp:  'When true, the vector vocabulary, allowing players to be used as vectors, is used.' projectLocal: true changeInformee: Preferences  changeSelector: #vectorVocabularySettingChanged.
Vocabulary initialize.
Preferences addPreference: #keepTickingWhilePainting category: #scripting default: false balloonHelp: 'If true, ticking scripts will keep running while in a painting session.'.