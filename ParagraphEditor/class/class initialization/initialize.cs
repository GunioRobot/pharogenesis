initialize 
	"Initialize the keyboard shortcut maps and the shared buffers
	for copying text across views and managing again and undo.
	Marked this method changed to trigger reinit" 
 
	"ParagraphEditor initialize"

	UndoSelection _ FindText _ ChangeText _ Text new.
	UndoMessage _ Message selector: #halt.

	self initializeCmdKeyShortcuts.
	self initializeShiftCmdKeyShortcuts.
	self initializeTextEditorMenus
