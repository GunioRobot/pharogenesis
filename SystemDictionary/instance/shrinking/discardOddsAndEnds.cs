discardOddsAndEnds
	"This method throws out lots of classes that are not frequently
	used."
	"Smalltalk discardOddsAndEnds"
	self organization removeSystemCategory: 'System-Serial Port'.
	self organization removeSystemCategory: 'ST80-Symbols'.
	self organization removeSystemCategory: 'Tools-File Contents Browser'.
	self organization removeSystemCategory: 'System-Compression'.
	self organization removeSystemCategory: 'Tools-Explorer'.
	self organization removeSystemCategory: 'System-Digital Signatures'.
	self organization removeSystemCategory: 'ST80-Paths'.
	"bit editor (remove Form editor first):"
	Form removeSelector: #bitEdit.
	StrikeFont removeSelector: #edit:.
	self removeClassNamed: #FormButtonCache.
	self removeClassNamed: #FormMenuController.
	self removeClassNamed: #FormMenuView.
	"self removeClassNamed: #BitEditor."
	"inspector for Dictionaries of Forms"
	Dictionary removeSelector: #inspectFormsWithLabel:.
	SystemDictionary removeSelector: #viewImageImports.
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