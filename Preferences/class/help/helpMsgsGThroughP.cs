helpMsgsGThroughP
		^ #(

(ignoreStyleIfOnlyBold
	'If true, then any method submission in which the only style change is for bolding will be treated as a method with no style specifications')

(inboardScrollbars
	'If true, then ScrollPane will place scrollbars inside on the right and will not hide them on exit')

(logDebuggerStackToFile
	'If true, whenever you fall into a debugger a summary of its stack will be written to a file named
''SqueakDebug.log''')

(menuColorFromWorld
	'Governs whether the colors used in morphic menus should be derived from the color of the world background.')

(mvcProjectsAllowed
	'If true, the open... menu will offer you the chance to open an mvc project.')

(noviceMode 
	'If true, certain novice-mode accommodations are made.')

(oneViewerFlapAtATime
	'If true, opening up one viewer flap will close all other such flaps.')

(optionalButtons
	'If true, then optional buttons will be used in certain standard tools, including browsers, message lists, fileLists, changeLists, and debuggers')

(personalizedWorldMenu
	'If true, then a right-click (Mac option-click) on the morphic desktop will bring up the customizable "personalized" menu; if false, then it will bring up the standard world menu.')

(preserveTrash
	'Whether morphs dismissed via halo or dragged into the Trash should be preserved in the TrashCan for possible future retrieval.  If false, they are not preserved.')

(printAlternateSyntax
	'If true, then
prettyPrint using experimental syntax.
Otherwise use normal ST-80 syntax.')

(projectsSentToDisk
	'If true, entering a new project swaps it in and swaps out other projects as appropriate. Projects are swapped in and out as ImageSegments, stored as files on disk in an image segment folder associated with the current image.')

(projectZoom
	'If true, then show a zoom effect when entering or leaving projects.  This can be costly of memory (at least an extra screen buffer) so dont use it in low space situations.  But it is cool.')

(promptForUpdateServer
	'If false, the prompt for server choice when updating code from the server is suppressed.  Set this to false to leave the server choice unchanged from update to update.')

			) 
