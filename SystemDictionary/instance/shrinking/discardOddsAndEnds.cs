discardOddsAndEnds
	"This method throws out lots of classes that are not frequently used."
	"Smalltalk discardOddsAndEnds"

	SystemOrganization removeSystemCategory: 'System-Serial Port'.
	SystemOrganization removeSystemCategory: 'ST80-Symbols'.
	SystemOrganization removeSystemCategory: 'Tools-File Contents Browser'.
	SystemOrganization removeSystemCategory: 'System-Compression'.
	SystemOrganization removeSystemCategory: 'Tools-Explorer'.
	SystemOrganization removeSystemCategory: 'System-Digital Signatures'.

	Form removeSelector: #edit.
	Smalltalk at: #FormView ifPresent:
		[:c | c compile: 'defaultControllerClass  ^ NoController'
			classified: 'controller access'].
	Smalltalk removeClassNamed: #FormEditorView.
	Smalltalk removeClassNamed: #FormEditor.
	SystemOrganization removeSystemCategory: 'ST80-Paths'.

	"bit editor (remove Form editor first):"
	Form removeSelector: #bitEdit.
	Form removeSelector: #bitEditAt:scale:.
	StrikeFont removeSelector: #edit:.
	Smalltalk removeClassNamed: #FormButtonCache.
	Smalltalk removeClassNamed: #FormMenuController.
	Smalltalk removeClassNamed: #FormMenuView.
	Smalltalk removeClassNamed: #BitEditor.

	"inspector for Dictionaries of Forms"
	Dictionary removeSelector: #inspectFormsWithLabel:.
	SystemDictionary removeSelector: #viewImageImports.
	ScreenController removeSelector: #viewImageImports.
	Smalltalk removeClassNamed: #FormHolderView.
	Smalltalk removeClassNamed: #FormInspectView.

	"experimental hand-drawn character recoginizer:"
	ParagraphEditor removeSelector: #recognizeCharacters.
	ParagraphEditor removeSelector: #recognizer:.
	ParagraphEditor removeSelector: #recognizeCharactersWhileMouseIn:.
	Smalltalk removeClassNamed: #CharRecog.

	"experimental updating object viewer:"
	Object removeSelector: #evaluate:wheneverChangeIn:.
	Smalltalk removeClassNamed: #ObjectViewer.
	Smalltalk removeClassNamed: #ObjectTracer.

	"miscellaneous classes:"
	Smalltalk removeClassNamed: #Array2D.
	Smalltalk removeClassNamed: #DriveACar.
	Smalltalk removeClassNamed: #EventRecorder.
	Smalltalk removeClassNamed: #FindTheLight.
	Smalltalk removeClassNamed: #PluggableTest.
	Smalltalk removeClassNamed: #SystemMonitor.
	Smalltalk removeClassNamed: #DocLibrary.

	Smalltalk removeClassNamed: #ProtocolBrowser.
	Smalltalk removeClassNamed: #ObjectExplorerWrapper.
	Smalltalk removeClassNamed: #HierarchyBrowser.
	Smalltalk removeClassNamed: #LinkedMessageSet.
	Smalltalk removeClassNamed: #ObjectExplorer.
	Smalltalk removeClassNamed: #PackageBrowser.
	Smalltalk removeClassNamed: #AbstractHierarchicalList.
	Smalltalk removeClassNamed: #ChangeList.
	Smalltalk removeClassNamed: #VersionsBrowser.
	Smalltalk removeClassNamed: #ChangeRecord.
	Smalltalk removeClassNamed: #SelectorBrowser.
	Smalltalk removeClassNamed: #HtmlFileStream.
	Smalltalk removeClassNamed: #CrLfFileStream.
	Smalltalk removeClassNamed: #FXGrafPort.
	Smalltalk removeClassNamed: #FXBlt.

	Smalltalk at: #SampledSound ifPresent: [:c |c initialize].
	#(Helvetica Palatino Courier ComicBold ComicPlain) do:
		[:k | TextConstants removeKey: k ifAbsent: []].

Preferences setButtonFontTo:	(StrikeFont familyName: #NewYork size: 12).
Preferences setFlapsFontTo:	(StrikeFont familyName: #NewYork size: 12).

#(GZipConstants ZipConstants KlattResonatorIndices ) do:
	[:k | Smalltalk removeKey: k ifAbsent: []].
