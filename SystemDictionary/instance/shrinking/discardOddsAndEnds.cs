discardOddsAndEnds
	"This method throws out lots of classes that are not frequently
	used."
	"Smalltalk discardOddsAndEnds"
	SystemOrganization removeSystemCategory: 'System-Serial Port'.
	SystemOrganization removeSystemCategory: 'ST80-Symbols'.
	SystemOrganization removeSystemCategory: 'Tools-File Contents Browser'.
	SystemOrganization removeSystemCategory: 'System-Compression'.
	SystemOrganization removeSystemCategory: 'Tools-Explorer'.
	SystemOrganization removeSystemCategory: 'System-Digital Signatures'.
	Form removeSelector: #edit.
	self
		at: #FormView
		ifPresent: [:c | c compile: 'defaultControllerClass  ^ NoController' classified: 'controller access'].
	self removeClassNamed: #FormEditorView.
	self removeClassNamed: #FormEditor.
	SystemOrganization removeSystemCategory: 'ST80-Paths'.
	"bit editor (remove Form editor first):"
	Form removeSelector: #bitEdit.
	Form removeSelector: #bitEditAt:scale:.
	StrikeFont removeSelector: #edit:.
	self removeClassNamed: #FormButtonCache.
	self removeClassNamed: #FormMenuController.
	self removeClassNamed: #FormMenuView.
	self removeClassNamed: #BitEditor.
	"inspector for Dictionaries of Forms"
	Dictionary removeSelector: #inspectFormsWithLabel:.
	SystemDictionary removeSelector: #viewImageImports.
	ScreenController removeSelector: #viewImageImports.
	self removeClassNamed: #FormHolderView.
	self removeClassNamed: #FormInspectView.
	"experimental hand-drawn character recoginizer:"
	ParagraphEditor removeSelector: #recognizeCharacters.
	ParagraphEditor removeSelector: #recognizer:.
	ParagraphEditor removeSelector: #recognizeCharactersWhileMouseIn:.
	self removeClassNamed: #CharRecog.
	"experimental updating object viewer:"
	Object removeSelector: #evaluate:wheneverChangeIn:.
	self removeClassNamed: #ObjectViewer.
	self removeClassNamed: #ObjectTracer.
	"miscellaneous classes:"
	self removeClassNamed: #Array2D.
	self removeClassNamed: #DriveACar.
	self removeClassNamed: #EventRecorder.
	self removeClassNamed: #FindTheLight.
	self removeClassNamed: #PluggableTest.
	self removeClassNamed: #SystemMonitor.
	self removeClassNamed: #DocLibrary.
	self removeClassNamed: #ProtocolBrowser.
	self removeClassNamed: #ObjectExplorerWrapper.
	self removeClassNamed: #HierarchyBrowser.
	self removeClassNamed: #LinkedMessageSet.
	self removeClassNamed: #ObjectExplorer.
	self removeClassNamed: #PackageBrowser.
	self removeClassNamed: #AbstractHierarchicalList.
	self removeClassNamed: #ChangeList.
	self removeClassNamed: #VersionsBrowser.
	self removeClassNamed: #ChangeRecord.
	self removeClassNamed: #SelectorBrowser.
	self removeClassNamed: #HtmlFileStream.
	self removeClassNamed: #CrLfFileStream.
	self removeClassNamed: #FXGrafPort.
	self removeClassNamed: #FXBlt.
	self
		at: #SampledSound
		ifPresent: [:c | c initialize].
	#(#Helvetica #Palatino #Courier #ComicBold #ComicPlain )
		do: [:k | TextConstants
				removeKey: k
				ifAbsent: []].
	Preferences
		setButtonFontTo: (StrikeFont familyName: #NewYork size: 12).
	Preferences
		setFlapsFontTo: (StrikeFont familyName: #NewYork size: 12).
	#(#GZipConstants #ZipConstants #KlattResonatorIndices )
		do: [:k | self
				removeKey: k
				ifAbsent: []]