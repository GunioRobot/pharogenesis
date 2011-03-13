updateFrom7001
	"self new updateFrom7001"
	
	"
	- updated SUnit packge (refactorings and a small bugfix)
	- SequenceableCollection.st from Connectors
	- BlockContext.st from Connectors
	- MessageSend.st from Connectors
	- TwoWayScrollPane.st from Connectors
	- Object.st from Connectors
	- CircleMorph.st from Connectors
	- TextMorph.st from Connectors
	- TileMorph.st from Connectors
	- SketchMorph.st from Connectors
	- StringMorphEditor.st from Connectors
	- EllipseMorph.st from Connectors
	- TTSampleStringMorph.st from Connectors
	- TTSampleFontMorph.st from Connectors
	- HandMorph.st from Connectors
	- SketchMorph.mir.1.cs from SqueakLand
	- TextMorph.mir.1.cs from SqueakLand
	Change Set:		PersMenuFix-wiz
	Author:			(wiz) Jerome Peace
	The Yellow button personal menu item  'about this system' throws up a DNU.
	The message is being sent to SmallTalk (the dictionary) instead of SmallTalkImage current.
	As I was here anyway I also took the time to remove the only reference to the isFlagship 	
	preference and the hardcoded preference method itself as per discussions with sw in mantis 	#2690.
	Change Set:		watcherTypeChange-sw
	Date:			24 March 2005
	Author:			Scott Wallace

	If the user changes the type of a Variable, watchers looking at that variable are now fixed 	up.   
	Any existing Watcher for the variable gets replaced by a labeled watcher appropriate 	for the new type.
	This is a fix for Squeakland Mantis bug #1001.
	- remove Preferences:  #selectionsMayShrink #warningForMacOSFileNameLength #celesteHasStatusPane.
	#celesteShowsAttachmentsFlag #autoAccessors #classicNewMorphMenu #morphicProgressStyle
	 #showLinesInHierarchyViews #testRunnerShowAbstractClasses
	- fix BlockContext>>#decompile to not reference Decompiler
	- add CompiledMethod#decompileWithTemps (logic was in 	Tools... sigh!)
	- ContextPart>>sourceCode simplified.
	"
	self script40.
	self flushCaches.
	Preferences removePreference: #selectionsMayShrink.
	Preferences removePreference: #warningForMacOSFileNameLength.
	Preferences removePreference: #celesteHasStatusPane.
	Preferences removePreference: #celesteShowsAttachmentsFlag.
	Preferences removePreference: #autoAccessors.
	Preferences removePreference: #classicNewMorphMenu.
	Preferences removePreference: #morphicProgressStyle.
	Preferences removePreference: #showLinesInHierarchyViews.
	Preferences removePreference: #testRunnerShowAbstractClasses.
	
	
