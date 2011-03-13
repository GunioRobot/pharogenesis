updateFrom7013
	"self new updateFrom7013"
	"
	updated to latest OmniBrowser
	-------
	Change Set:		AddLineToTTCFont-yo
	Date:			1 August 2005
	Author:			Yoshiki Ohshima

	call #addLined on demand.  It should be handled more statically, but I have a feeling that 
	writing out TTCFont with LinedTTC in their derivative may not be handled very cleverly.
	--------------
	Change Set:		TTCRegistry-yo
	Date:			1 August 2005
	Author:			Yoshiki Ohshima

	A class variable (Registry) was missing from the class definition of TTCFont.  This change 
	set re-instate that, and register everything in postscript.
	--------------
	Change Set:		ttcNewSizeFix
	Date:			3 August 2005
	Author:			Yoshiki Ohshima

	Fallback font handling for new sized font has a bug.  The main problem is that 
	FixedFaceFont doesn't have the corresponding TextStyle.  I could add it, but so far I gave nil 
	to some implicit semantics in the methods in this change set.
	------------------
	Change Set:		searchPaneFix-sw
	Date:			3 August 2005
	Author:			Scott Wallace

	Make viewer search panes clip their submorphs, thus avoiding an ugly green artifact that 
	had crept in.  (Thanks to Andreas for supplying the fix.)
	-------------------
	Change Set:		AddTranslationNov30
	Date:			30 November 2005
	Author:			Yoshiki Ohshima

	Adds #translated to the ? halo of buttons.
	-------------------
	Change Set:		fixFileList2-bf
	Date:			5 December 2005
	Author:			Bert Freudenberg

	Fix image opening in FileList2
	--------------------
	0446ProjLoadFixes.cs 
	---------------------
	Change Set:		joystickEnh-mir-bf
	Date:			5 September 2005
	Author:			Michael Rueger, Bert Freudenberg

	Make joystick buttons available in Etoys.
	---------------------
	Change Set:		URLEncodingAttempt
	Date:			29 July 2005
	Author:			Yoshiki Ohshima

	An attempt to support more characters in encodeForHTTP.  However, this introduces another 
	backward compatibility problem.  The default behavior of #encodeForHTTP uses UTF-8 as the 
	byte sequence interpretation, but it was Latin-1 for older implementation.

	To get the backward compatible behavior, the senders of #encodeForHTTP should use an 	expression:

	aString encodeForHTTPWithTextEncoding: 'latin1'.

	instead.

	This changeset suppress the trivial error, but may cause the problem when somebody tries 
	to load a project from older image with latin-1 characters in its name.
	------------------
	0448loadNihongo4Projects.cs
	------------------
	Change Set:		worldPreferences-sw
	Date:			3 August 2005
	Author:			Scott Wallace

	Don't show the Preferences category in the world's viewer in eToyFriendly mode.

	When *not* in eToyFriendly mode, do show the category, to which othe alternatives have
 	now been added.
	------------
	Change Set:		vectorError-sw
	Date:			3 August 2005
	Author:			Scott Wallace

	Circumvents error condition when clicking on the menu icon of some of the 
	vector-vocabulary phrases.
	-------------
	Change Set:		EditableWatcher
	Date:			2 August 2005
	Author:			Takashi Yamamiya

	This fix allows you to edit variables with simple watchers
	-------------
	Change Set:		playfieldPrefBug-sw
	Date:			12 August 2005
	Author:			Scott Wallace

	Fixes the bug that the Preferences category could show up in the viewer of a non-world.
	-----------
	Change Set:		KedamaFixesAug
	Date:			15 August 2005
	Author:			Yoshiki Ohshima

	some fixes for a few known bugs.
	------------
	Change Set:		KedamaFixesAug2
	Date:			17 August 2005
	Author:			Yoshiki Ohshima

	suppress the dup halo for turtle exemplars, and make the forms in patches behaves better.
	------------
	Change Set:		symbolTranslationFix
	Date:			18 August 2005
	Author:			Yoshiki Ohshima

	Fix a few more problems with language transition.
	-------------
	Change Set:		KedamaFixesAug3
	Date:			19 August 2005
	Author:			Yoshiki Ohshima

	The backup code for a primitive was wrong.  It shows wrong boundary behavior when the 	
	plugin is not present.
	--------------
	Change Set:		fixObsDefault
	Date:			1 September 2005
	Author:			Michael Rueger

	Removes obsolete default messages and references still using them.
	------------
	"
	self script51.
	self flushCaches.
	MCDefinition clearInstances.
	TTCFont registerAll