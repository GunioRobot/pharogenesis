majorShrink    "Smalltalk majorShrink; abandonSources; lastRemoval"
	"This method throws out lots of the system that is not needed for, eg, operation in a hand-held PC.  The shrink process is being improved and, in conjunction with removeAllUnSentMessages, yields an image around 600k in size."

	"Remove references to a few classes to be deleted, so that they won't leave obsolete versions around."
	FormView compile: 'defaultControllerClass 
	^  NoController' classified: 'controller access'.
	FileModel removeSelector: #fileIntoNewChangeSet.
	Form removeSelector: #edit.
	ChangeSet class compile: 'defaultName
		^ ''Changes'' ' classified: 'initialization'.
	ScreenController removeSelector: #openChangeManager.
	ScreenController removeSelector: #exitProject.
	ScreenController removeSelector: #openProject.
	ScreenController removeSelector: #viewGIFImports.

	"Now delete lots of classes.."
	(Smalltalk includesKey: #CCodeGenerator) ifTrue:
		[(Smalltalk at: #CCodeGenerator) removeCompilerMethods].
	SystemOrganization removeSystemCategory: 'Squeak Interpreter'.
	SystemOrganization removeSystemCategory: 'Translation to C'.
	(SystemOrganization categories select: [:c | 'Morphic*' match: c]) reverseDo:
		[:c | SystemOrganization removeSystemCategory: c].
	SystemOrganization removeSystemCategory: 'System-Network'.
	SystemOrganization removeSystemCategory: 'System-Monitoring'.
	SystemOrganization removeSystemCategory: 'Graphics-Symbols'.
	SystemOrganization removeSystemCategory: 'Graphics-Files'.
	SystemOrganization removeSystemCategory: 'Interface-Pluggable'.
	SystemOrganization removeSystemCategory: 'Interface-Projects'.
	SystemOrganization removeSystemCategory: 'Object Storage'.
	SystemOrganization removeSystemCategory: 'System-Sound'.

	FormEditor removeFromSystem.
	FormEditorView removeFromSystem.
	FormMenuView removeFromSystem.
	FormMenuController removeFromSystem.
	FormButtonCache removeFromSystem.

	CurveFitter removeFromSystem.
	LinearFit removeFromSystem.
	Spline removeFromSystem.
	Circle removeFromSystem.
	Arc removeFromSystem.
	FormSetFont removeFromSystem.
	FontSet removeFromSystem.
	InstructionPrinter removeFromSystem.
	SharedQueue removeFromSystem.
	TextLinkToImplementors removeFromSystem.

	ParagraphEditor removeSelector: #recognizeCharacters.
	ParagraphEditor removeSelector: #recognizer:.
	ParagraphEditor removeSelector: #recognizeCharactersWhileMouseIn:.
	CharRecog removeFromSystem.
	Array2D removeFromSystem.
	FFT removeFromSystem.

	ChangeSorter removeFromSystem.
	DualChangeSorter removeFromSystem.
	CngsClassList removeFromSystem.
	CngsMsgList removeFromSystem.
	TriggerController removeFromSystem.
	MessageTally removeFromSystem.
	BitEditor removeFromSystem.

	StringHolder class removeSelector: #originalWorkspaceContents.
	CompiledMethod removeSelector: #symbolic.
	StringHolder systemWorkspaceContents: ''.
	TextConstants removeKey: #ClairVaux.  "Gets rid of a couple of fonts"

	FormHolderView removeFromSystem.
	FormInspectView removeFromSystem.
	GeneralListView removeFromSystem.
	GeneralListController removeFromSystem.
	HierarchicalMenu removeFromSystem.
	EmphasizedMenu removeFromSystem.
	ObjectViewer removeFromSystem.
	ObjectTracer removeFromSystem.
	HtmlFileStream removeFromSystem.
	ConciseInspector removeFromSystem.

	TextStyle allInstancesDo:
		[:ts | (ts instVarAt: 1) size > 2 ifTrue:  "Only need two fonts"
			[ts instVarAt: 1 put: ((ts instVarAt: 1) copyFrom: 1 to: 2)]].
	ListParagraph initialize.
	PopUpMenu initialize.
	StandardSystemView initialize.

	Smalltalk noChanges.
	ChangeSorter classPool at: #AllChangeSets put: (OrderedCollection with: Smalltalk changes).

	[self removeAllUnSentMessages > 0] whileTrue.
	Smalltalk allClassesDo: [:c | c zapOrganization].
	Symbol rehash.
