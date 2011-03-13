initialize
	"Initialize the keyboard shortcut maps and the shared buffers for copying text across views and managing again and undo.
	6/18/96 sw: call initializeTextEditorMenus
	other times: marked change to trigger reinit"

	"ParagraphEditor initialize"

	CurrentSelection _ UndoSelection _ FindText _ ChangeText _ Text new.
	UndoMessage _ Message selector: #halt.

	self initializeCmdKeyShortcuts.
	self initializeShiftCmdKeyShortcuts.

	self initializeTextEditorMenus
