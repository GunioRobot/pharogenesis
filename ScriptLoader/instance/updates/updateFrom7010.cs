updateFrom7010
	"self new updateFrom7010"
	"
	Change Set:		watcherTypeChgFix-sw
	Date:			25 July 2005
	Author:			Scott Wallace

	Makes the new watchers launched to replace existing ones upon a type-change to a variable 	conform to the new protocol for creating watchers; also fixes the bug that simple watchers 	were being replaced by fancy ones after a type change.
	---------------------------
	Change Set:		StringEqual2
	Date:			15 December 2005
	Author:			Yoshiki Ohshima

	'abc' = 'abc' asWideString wasn't returning true after the String refactoring.  Supposedly, 	primitiveCompareString should fail when the argument or receiver isn't a byte object, but 	currently the primitive just traverses the internal of the word object.  The right fix would 	be to fix the primitive, but so far the Squeak side code should cope with it.
	------------------------------
	Change Set:		tileFix-sw
	Date:			18 July 2005
	Author:			Scott Wallace
	The tear-off-a-tile halo handle could sometimes tear off a bogus tile, if a non-Sketch object 	was rotated before a player was allocated to it.  This update fixes that.  Thanks to Dave 	Briccetti for pointing out this bug.
	--------
	Change Set:		FixMorphDelete
	Date:			28 July 2005
	Author:			Andreas Raab

	Always #dismissViaHalo even if #preserveTrash is true.
	--------
	Change Set:		ProjectViewDismiss
	Date:			1 August 2005
	Author:			Yoshiki Ohshima

	Match the wording when a ProjectViewMorph is dismissed via halo.
	-------
	Change Set:		turnTowardFix-sw
	Date:			29 July 2005
	Author:			Scott Wallace

	As per suggestion from Randy Heiland, Squeakland mailing list 7/29/05, makes 'turn toward' 	always carry out the turn (unless the positions of the two objects coincide), whether or not 	the objects overlap.
	--------
	0461MophDissmissal.cs
	--------
	Change Set:		LocaleRefactoring
	Date:			8 August 2005
	Author:			Takashi Yamamiya
	-------
	Change Set:		localeEnabler
	Date:			31 August 2005
	Author:			Michael Rueger

	Enables the use of the language setting through the locale plugin. If no plugin is found, 	the current locale is used.
	The preference useLocale turns the automatic settings on or off.
	-----------
	Change Set:		smWorkaround-sw
	Date:			16 March 2006
	Author:			Scott Wallace, Michael Rueger

	Adapted for 3.9.
	A change to allow SqueakMap to load packages successfully into images whose version 	numbers are less than 5302, which is the Squeak.org update level at which the convention 	about where the system changes were stored changed.  Goran's version of this code (7/13/04) 	assumed that any version number less than 5302 indicated an ancient Squeak, whereas in 	practice nowadays it is much more likely to indicate a recent Squeak that has a different 	formal version name, such as 'Tweak1.2' or Squeakland3.8', and which has its own 	sequence of update numbers.  This workaround was prompted a need to load Monticello into 	the Squeakland image.
	"
	self script48.
	self flushCaches.
	MCDefinition clearInstances.
	
	Preferences enable: #dropProducesWatcher.
	Preferences addPreference: #showAdvancedNavigatorButtons category: #morphic default: true balloonHelp: 'If true, an advanced version of the navigator is shown, otherwise a simplified version.'.