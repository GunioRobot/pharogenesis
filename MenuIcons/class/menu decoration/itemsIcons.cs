itemsIcons
	"answer a collection of associations wordings -> icon to  
	decorate  
	the menus all over the image"
	| icons |
	icons := OrderedCollection new.
	" 
	world menu"
	icons add: #('previous project' ) -> self smallBackIcon.
	icons add: #('select' ) -> self smallSelectIcon.
	icons add: #('jump to project...' ) -> self smallForwardIcon.
	icons add: #('open...' ) -> self smallOpenIcon.
	icons add: #('appearance...' ) -> self smallConfigurationIcon.
	icons add: #('help...' ) -> self smallHelpIcon.
	icons add: #('windows...' ) -> self smallWindowIcon.
	icons add: #('print PS to file...' ) -> self smallPrintIcon.
	icons add: #('debug...' ) -> self smallDebugIcon.
	icons add: #('export...' ) -> self smallExportIcon.
	icons add: #('save' ) -> self smallSaveIcon.
	icons add: #('save project on file...' ) -> self smallPublishIcon.
	icons add: #('save as...' 'save as new version' ) -> self smallSaveAsIcon.
	icons add: #('quit' 'save and quit' ) -> self smallQuitIcon.
	icons add: #('load project from file...' ) -> self smallLoadProjectIcon.
	""
	icons add: #('do it (d)' ) -> self smallDoItIcon.
	icons add: #('inspect it (i)' 'explore it (I)' 'inspect world' 'explore world' 'inspect model' 'inspect morph' 'explore morph' 'inspect owner chain' 'explore' 'inspect' 'explore (I)' 'inspect (i)' 'basic inspect' ) -> self smallInspectItIcon.
	icons add: #('print it (p)' ) -> self smallPrintIcon.
	icons add: #('debug it' ) -> self smallDebugIcon.
	""
	icons add: #('copy (c)' 'copy to paste buffer' 'copy text' ) -> self smallCopyIcon.
	icons add: #('paste (v)' 'paste...' ) -> self smallPasteIcon.
	icons add: #('cut (x)' ) -> self smallCutIcon.
	""
	icons add: #('accept (s)' 'yes' 'Yes' ) -> self smallOkIcon.
	icons add: #('cancel (l)' 'no' 'No' ) -> self smallCancelIcon.
	""
	icons add: #('do again (j)' ) -> self smallRedoIcon.
	icons add: #('undo (z)' ) -> self smallUndoIcon.
	""
	icons add: #('find...(f)' 'find again (g)' 'find class... (f)' 'find method...' ) -> self smallFindIcon.
	""
	icons add: #('remove' 'remove class (x)' 'delete method from changeset (d)' 'remove method from system (x)' 'delete class from change set (d)' 'remove class from system (x)' 'destroy change set (X)' ) -> self smallDeleteIcon.
	icons add: #('add item...' 'new category...' 'new change set... (n)' ) -> self smallNewIcon.
	""
	icons add: #('new morph...' 'objects (o)' ) -> self smallObjectCatalogIcon.
	icons add: #('authoring tools...')  -> self smallAuthoringToolsIcon.
	""
	icons add: #('leftFlush' ) -> self smallLeftFlushIcon.
	icons add: #('rightFlush' ) -> self smallRightFlushIcon.
	icons add: #('centered' 'set alignment... (u)' ) -> self smallCenteredIcon.
	icons add: #('justified' ) -> self smallJustifiedIcon.
	""
	icons add: #('set font... (k)' 'list font...' 'set subtitles font' 'change font' 'system fonts...' 'change font...' ) -> self smallFontsIcon.
	icons add: #('full screen on' 'full screen off' ) -> self smallFullScreenIcon.
	""
	^ icons