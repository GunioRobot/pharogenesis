helpMsgsAThroughF
	"This, and the other methodds in this category, are automatically called whenever you call

   	Preferences initializeHelpMessages
		or
	Preferences callHelpMessageInitializers
"

	^ #( 
(autoAccessors
	'If true, an attempt to call a message which is not understood by an object but whose selector is the same as an inst var of the object will result in automatic compilation of an accessor method for that object''s class')

(automaticViewerPlacement
	'If true, new viewers are automatically positioned near the objects they view; if false, new viewers are attached to the hand, from whence you much choose a destination for them')

(annotationPanes
	'If true, a thin horizontal annotation pane is used in browsers.')

(balloonHelpEnabled
	'Whether balloon help should be offered when the cursor lingers over certain objects.')

(browserShowsPackagePane
	'If true, then the various ''browse full'' and ''browse it'' commands (usually invoked via cmd-b) will open a Package Browser rather than a System Browser.  The Package Browser includes a package pane which groups system categories into packages based on the initial portion of their category name.')

(browseWithPrettyPrint
	'If true, browsers will automatically format their contents')

(cautionBeforeClosing 
	'If true, Morphic windows seen in an mvc project will put up a warning before allowing themselves to be dismissed')

(caseSensitiveFinds
	'If true, then the "find" command in text will always make its searches in a case-sensitive fashion')

(changeSetVersionNumbers
	'If true, version-number extensions will be used when constructing names for change-set fileouts.  If false, timestamp extensions are used.')

(checkForSlips 
	'If true, then whenever you file out a change set, it is checked for ''slips'' and if any are found, you are so informed and given a chance to open a browser on them')

(clickOnLabelToEdit
	'If true, a click on the label of a system window lets you edit it; if false, allow dragging of system windows when clicking on the label')

(cmdDotEnabled
	'If true, cmd-dot brings up a debugger;
if false, the cmd-dot interrupt is disabled')

(colorWhenPrettyPrinting
	'If true, then when browseWithPrettyPrint is in effect, the pretty-printing will be presented in color')

(compressFlashImages
	'If true, flash images will automatically be reduced to 8-bit color depth upon being read')

(confirmFirstUseOfStyle
'If true, the first attempt to submit a method with non-standard style will bring up a confirmation dialog')

(conversionMethodsAtFileOut
	'Governs whether at fileout time you should be prompted to define conversion methods where deemed appropriate.')

(debugHaloHandle 
'If true, a special debugging halo handle is displayed at the right of the halo; if false, no such handle is shown.')

(diffsInChangeList
	'If true, changeList browsers and Versions browsers will open up by default showing diffs, i.e. revealing the differences between successive versions or between the in-memory code and the code on disk')

(editPlayerScriptsInPlace 
	'If true, textual player scripts are edited in place in Scriptors (still imperfectly implemented)')

(eToyScheme
	'If true, new scripting spaces place the Playfield to the left and the the palette to the right of the window; if false, the opposite is true.')

(extractFlashInHighQuality
	'Whether flash graphics should be extracted in high quality.')
(extractFlashInHighestQuality
	'Whether flash graphics should be extracted in highest possible quality.')

(fastDragWindowForMorphic
	'If true, morphic window drag will be done by dragging an outline of the window.')

(fenceEnabled
	'Whether an object obeying motion scripts should stop moving when it reaches the edge of its container.')

) 
