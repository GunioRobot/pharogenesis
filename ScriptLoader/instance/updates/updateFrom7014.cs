updateFrom7014
	"self new updateFrom7013"
	"
	Change Set:		0479iso3Countries.cs
	Date:			1 September 2005
	Author:			John Mcintosh, Michael Rueger

	Add ISO3 country codes to the iso definitions
	-------------
	Change Set:	phraseDupFix-sw
	Date:			23 October 2005
	Author:		Scott Wallace

	Fixes a bug that broke the duplication of phrase tiles that don't reside in viewers
	-------------
	Change Set:		suppliesTwoLiner
	Date:			7 October 2005
	Author:			Scott Wallace, Michael Rueger

	changes the supplies flap to show two lines of items by default
	--------------
	0498MacUnicodeIInterp.cs
	---------------
	Change Set:		FontRegistryFix
	Date:			9 October 2005
	Author:			Yoshiki Ohshima

	registry wasn't properly used for TTCFont.
	----------------
	Change Set:		percentEncodingFix
	Date:			22 September 2005
	Author:			Korakurider

	+ When Squeak is launched by openning .pr file, passed filename is systemString
	 (shift-jis on windows for instance).  That has to be converted to Squeak-native string.
	+ reimplementation of decoding percent-encoded-string has to be modified to support
	  utf8 based encoding.
	------------------
	0502nebraskaBuffer-yo.cs 
	-------------------
	Change Set:		NebraskaTextAndImageFix
	Date:			6 October 2005
	Author:			Yoshiki Ohshima

	* DropShadow + Text + Nebraska wasn't working right.
	* Form depth = 32 wasn't working right.  It isn't right or optimal but better in many ways.
	------------------
	Change Set:		revertStamp-tak
	Date:			28 November 2005
	Author:			Takashi Yamamiya

	Revert stampOnTransformedOwner.cs (it is included in 6580changesFromSql38ToJa)
	to fix a problem of stamp of rotated object.
	--------------------
	Change Set:		nebraskaBuffer2-yo
	Date:			10 October 2005
	Author:			Yoshiki Oshima

	Republished as Squeakland update 0506 to make certain that the code will be present in 
	images that had already loaded SqueakAlpha update 0502testPercentEncoding before it was 
	rescinded.
	--------------------
	Change Set:		FixKedamaBundle
	Date:			23 October 2005
	Author:			Yoshiki Ohshima

	KedamaBundle used to create an extra patch.
	---------------------
	Change Set:		BOMLangEditor
	Date:			29 November 2005
	Author:			Yoshiki Ohshima

	Fix BOM problem in Language Editor.
	--------------------
	Change Set:		ProjectManifest
	Date:			29 November 2005
	Author:			Yoshiki Ohshima

	Put a 'manifest' file that stores some additional infomation about the project.
	----------------------
	Change Set:		macosxJaMarks
	Date:			22 November 2005
	Author:			Tetsuya Hayashi

	Fixes Japanese input method related problem.
	It dealsd with special case involved in unicode conversion.
	-----------------------
	Change Set:		setupLanguageSpec-tak
	Date:			28 November 2005
	Author:			Takashi Yamamiya

	- Add language specific settings.
	- Remove setup scripts for old Japanese image.
	---------------------
	Change Set:		variableCategory-ka
	Date:			29 November 2005
	Author:			Kazuhiro Abe

	Patch for 'variable category doesn't apper when it's needed'.
	It occurs because missing 'translated' message after 'ScriptingSystem 
	nameForInstanceVariablesCategory' in StandardViewer>>likelyCategoryToShow.
	------------------------
	Change Set:		Use32BitPatch
	Date:			30 November 2005
	Author:			Yoshiki Ohshima
	-------------------------
	Change Set:		TextAlignEmphMenu-KR
	Date:			5 December 2005
	Author:			Korakurider

	fix problem that current alignment is shown wrongly on emphasis/alignment Menu for 
	TextMorph
	------------------------
	Change Set:		colorPickerFix-KR
	Date:			14 December 2005
	Author:			Korakurider

	Get the alpha setting on a morph's property sheet's fill-color colorpicker set properly.
	------------------------------
	Change Set:		shouldntBeRounded-ka
	Date:			4 December 2005
	Author:			Kazuhiro Abe

	Some morph, such as an Ellipse or a Polygon, shouldn't have rounded corners.
	They drew fake corners.
	------------------------------------
	Change Set:		FixAssignmentSuffix
	Date:			15 December 2005
	Author:			Takashi Yamamiya

	Fixed duplicated assignment arrows in old project.

	To load old project which is made in 3.2 era, assignment arrows (_) are
	duplicated. The reason is sometimes symbols and strings are confused in
	#translatedWordingFor:.
	----------------------------
	Change Set:		fixCharConv128-255
	Date:			5 November 2005
	Author:			Takashi Yamamiya

	Some characters could not be converted from Squeak to OS encoding.

	To reproduce:
	- Open workspace.
	- Input MULTIPLICATION SIGN character with your IME.
	- select and copy a few times for copying to the system paste buffer.
	- You would see an error.

	Reason: A charactor which value is 128-255 should be converted.

	e.g.
	00D7 MULTIPLICATION SIGN 
	00F7 DIVISION SIGN
	see http://www.unicode.org/charts/PDF/U0080.pdf
	-------------------------
	Change Set:		fixManifest
	Date:			16 December 2005
	Author:			Korakurider

	fix and enhance the facility to save manifest of project:
	  + Original implementation use constant filename 'MANIFEST'.
	    That behavior causes conflict of filename on server(Swiki etc).
	    This patch use basename of project for file name for manifest
 	+ save latest update number of SmalltalkImage in manifest (enhancement)
	----------------------------
	0528FixAPartOfBobConv.cs 
	"
	
	self script52.
	self flushCaches.
	MCDefinition clearInstances.
	
	ISOLanguageDefinition initISOCountries.
	
	Preferences addPreference: #duplicateAllControlAndAltKeys category: #keyboard default: true balloonHelp: 'If true, duplicates all alt- keys as ctrl-keys (making ctrl-c be copy as well as alt-c).
Cannot be true if swapControlAndAltKeys or duplicateControlAndAltKeys are true.'.

Preferences addPreference: #duplicateControlAndAltKeys category: #keyboard default: false balloonHelp: 'If true, duplicates some alt- keys as ctrl- keys (making ctrl-c be copy as well as alt-c).
Cannot be true if swapControlAndAltKeys or duplicateAllControlAndAltKeys are true.'.

Preferences addPreference: #swapControlAndAltKeys category: #keyboard default: false balloonHelp:  'If true, swaps some control- and alt-keys (making ctrl-c be copy instead of alt-c). 
Cannot be true if duplicateControlAndAltKeys or duplicateAllControlAndAltKeys is true.'.

(Preferences preferenceAt: #honorDesktopCmdKeys) categoryList: #(#keyboard #menus).

(Preferences preferenceAt: #duplicateAllControlAndAltKeys) rawValue: false.
(Preferences preferenceAt: #duplicateControlAndAltKeys) rawValue: false.
(Preferences preferenceAt: #swapControlAndAltKeys) rawValue: false.

(Preferences preferenceAt: #duplicateAllControlAndAltKeys) changeInformee: InputSensor changeSelector: #duplicateAllControlAndAltKeysChanged.
(Preferences preferenceAt: #duplicateControlAndAltKeys) changeInformee: InputSensor changeSelector: #duplicateControlAndAltKeysChanged.
(Preferences preferenceAt: #swapControlAndAltKeys) changeInformee: InputSensor changeSelector: #swapControlAndAltKeysChanged.

(Preferences preferenceAt: #duplicateAllControlAndAltKeys) preferenceValue: true.
