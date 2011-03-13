updateFrom6716
	"Bugfixes"
	
	"Change Set:		isSourceFileSuffix-M1407
	Date:			15 September 2005
	Author:			tim@rowledge.org
	A trivial change to FileStream class>isSourceFileSuffix: to remove the spurious seeming   
	inclusion of '*' as a legitimate source file suffix.  Seems to break nothing.
	----
	Change Set:		selectorsWithArgs-md
	Date:			2 January 2006
	Author:			Marcus Denker
	Make Behavior>>#selectorsWithArgs: use symbol>>#numArgs.
	Much simpler: one line. And it fixes a bug.
	----
	Change Set:		removeUndefTest
	Date:			14 January 2006
	Author:			Marcus Denker
	removes UndefinedObject>>#test, which was a test method for alternate syntax
	-----
	0002373: ParagraphEditor >> #makeCapitalized: comment is not correct
	-----
	Change Set:		SysWindowClean01-wiz
	Date:			18 January 2006
	Author:			(wiz) Jerome Peace
	wiz 1/18/2006 15:34
	Ok. I think that does it.
	Removed unused preference and SystemWindow methods that use it Mantis # 2532.
	------
	Change Set:		decompileBlock-md
	Date:			24 November 2005
	Author:			Marcus Denker
	A  simplification for BlockContext>>decompileBlock:
	The Method got the tempNames by compiling the source of the method. This
	is already implemented in methodNode tempNames... thus not needed here.
	------
	remove emptycheck for Heap>>fist and SequencableCollection
	#first, #last, #middle
	------
	0002514: [FIX] condenseSources (was: Re: [Q] Removing changes file content.
	------
	Delay startTimerInterruptWatcher
	to fix
	0002379: BlockContext>>decompile broken, ProcessBrowser does not work
	------
	0002377: Cannot rename a project from its window menu
	0002497: MNU when changing title on Morphic Project
	0002415: Error after one presses ESC key two times.
	0002145: KlattFrame: ZeroDivide exception when the value of ro, rk or ra is 0
	-----
	Change Set:		FileListCodeDNUfix-efc
	Author:			Eddie Cottongim
	Apparently Object got (errantly?) registered with FileList as a file reader. This was throwing 	some DNUs. This simple doit unregisters Object and appears to solve the problem.
	-----
	Change Set:		RemoveAlternateSynPref
	-----
	Change Set:		PlusToolsAlternateSyntaxFix
	Date:			14 January 2006
	Author:			Marcus Denker
	The horrible alternateSyntax hack has been removed in 3.9. This fixes
	three methods in the plustools to not use definitionST80: but definitionST80
	------
	"
	self script27.
	self flushCaches.
	Delay startTimerInterruptWatcher.
	FileList unregisterFileReader: Object.
	Preferences removePreference: #printAlternateSyntax.

	