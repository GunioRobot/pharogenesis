openMenu
	"Build the open window menu for the world."

	| menu |
	menu _ self menu: 'open...'.
	self fillIn: menu from: {

		{'browser (b)' . { self . #openBrowser}. 'A five-paned tool that lets you see all the code in the system'}.
		{'package-pane browser' . { PackagePaneBrowser . #openBrowser} . 'Similar to the regular browser, but adds an extra pane at top-left that groups class-categories that start with the same prefix' }.
		{'workspace (k)' . {self . #openWorkspace}. 'A window for composing text' }.
		{'file list' . {self . #openFileList} . 'A tool allowing you to browse any file' }.
		{'file...' . { FileList . #openFileDirectly} . 'Lets you open a window on a single file'}.
		{'transcript (t)' . {self . #openTranscript}. 'A window used to report messages sent to Transcript' }.
		"{'inner world' . { WorldWindow . #test1} }."
		nil.
		{'method finder' . { self . #openSelectorBrowser} . 'A tool for discovering methods' }.
		{'message names (W)' . { self . #openMessageNames} . 'A tool for finding and editing methods that contain any given keyword in their names.'}.
			 nil.
		{'simple change sorter' . {self . #openChangeSorter1} . 'A tool allowing you to view the methods in a single change set' }.
		{'dual change sorter' . {self . #openChangeSorter2} . 'A tool allowing you to compare and manipulate two change sets concurrently' }.
		nil.
	}.
	self fillIn: menu from: self class registeredOpenCommands.
	menu addLine.

	self mvcProjectsAllowed ifTrue:
		[self fillIn: menu from: { {'mvc project' . {self. #openMVCProject} . 'Creates a new project of the classic "mvc" style'} }].

	^ self fillIn: menu from: { 
		{'morphic project' . {self. #openMorphicProject} . 'Creates a new morphic project'}.
	}.