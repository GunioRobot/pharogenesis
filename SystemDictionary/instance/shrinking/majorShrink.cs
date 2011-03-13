majorShrink
	"Undertake a major shrinkage of the image.
	This method throws out lots of the system that is not needed
	for, eg, operation in a hand-held PC. majorShrink produces a
	999k image in Squeak 2.8
	Smalltalk majorShrink; abandonSources; lastRemoval"
	| oldDicts newDicts |
	self error: 'You can only run majorShrink in MVC'.
	Project current isTopProject
		ifFalse: [^ self error: 'You can only run majorShrink in the top project'].
	(self confirm: 'All sub-projects will be deleted from this image.
You should already have made a backup copy,
or you must save with a different name after shrinking.
Shall we proceed to discard most of the content in this image?')
		ifFalse: [^ self inform: 'No changes have been made.'].
	"Remove all projects but the current one. - saves 522k"
	Project current setParent: Project current.
	MorphicModel removeUninstantiatedModels.
	Utilities classPool at: #ScrapsBook put: nil.
	Utilities zapUpdateDownloader.
	Project rebuildAllProjects.
	"Smalltalk discardVMConstruction."
	"755k"
	self discardSoundSynthesis.
	"544k"
	self discardOddsAndEnds.
	"227k"
	self discardNetworking.
	"234k"
	"Smalltalk discard3D."
	"407k"
	self discardFFI.
	"33k"
	self discardMorphic.
	"1372k"
	Symbol rehash.
	"40k"
	"Above by itself saves about 4,238k"
	"Remove references to a few classes to be deleted, so that they
	won't leave obsolete versions around."
	ChangeSet class compile: 'defaultName
		^ ''Changes'' ' classified: 'initialization'.
	"Now delete various other classes.."
	SystemOrganization removeSystemCategory: 'Graphics-Files'.
	SystemOrganization removeSystemCategory: 'System-Object Storage'.
	"Smalltalk removeClassNamed: #Project."
	self removeClassNamed: #FormSetFont.
	self removeClassNamed: #FontSet.
	self removeClassNamed: #InstructionPrinter.
	self removeClassNamed: #ChangeSorter.
	self removeClassNamed: #DualChangeSorter.
	self removeClassNamed: #EmphasizedMenu.
	self removeClassNamed: #MessageTally.
	StringHolder class removeSelector: #originalWorkspaceContents.
	CompiledMethod removeSelector: #symbolic.
	RemoteString removeSelector: #makeNewTextAttVersion.
	self removeClassNamed: #PenPointRecorder.
	self removeClassNamed: #Path.
	self removeClassNamed: #Base64MimeConverter.
	self removeClassNamed: #RWBinaryOrTextStream.
	self removeClassNamed: #AttributedTextStream.
	self removeClassNamed: #WordNet.
	self removeClassNamed: #SelectorBrowser.
	TextStyle
		allSubInstancesDo: [:ts | ts
				newFontArray: (ts fontArray
						copyFrom: 1
						to: (2 min: ts fontArray size))].
	ListParagraph initialize.
	PopUpMenu initialize.
	ChangeSet noChanges.
	ChangeSet classPool
		at: #AllChangeSets
		put: (OrderedCollection with: ChangeSet current).
	SystemDictionary removeSelector: #majorShrink.
	[self removeAllUnsentMessages > 0]
		whileTrue: [Smalltalk unusedClasses
				do: [:c | (Smalltalk at: c) removeFromSystem]].
	SystemOrganization removeEmptyCategories.
	self
		allClassesDo: [:c | c zapOrganization].
	self garbageCollect.
	'Rehashing method dictionaries . . .'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: MethodDictionary instanceCount
		during: [:bar | 
			oldDicts := MethodDictionary allInstances.
			newDicts := Array new: oldDicts size.
			oldDicts
				withIndexDo: [:d :index | 
					bar value: index.
					newDicts at: index put: d rehashWithoutBecome].
			oldDicts elementsExchangeIdentityWith: newDicts].
	oldDicts := newDicts := nil.
	Project rebuildAllProjects.
	ChangeSet current initialize.
	"seems to take more than one try to gc all the weak refs in
	SymbolTable "
	3
		timesRepeat: [self garbageCollect.
			Symbol compactSymbolTable]