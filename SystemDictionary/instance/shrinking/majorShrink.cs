majorShrink    "Smalltalk majorShrink; abandonSources; lastRemoval"
	"This method throws out lots of the system that is not needed for, eg, operation in a hand-held PC.  majorShrink produces a 999k image in Squeak 2.8"

	Smalltalk isMorphic ifTrue: [^ self error: 'You can only run majorShrink in MVC'].
	Project current isTopProject ifFalse: [^ self error: 'You can only run majorShrink in the top project'].
	(Smalltalk confirm: 'All sub-projects will be deleted from this image.
You should already have made a backup copy,
or you must save with a different name after shrinking.
Shall we proceed to discard most of the content in this image?')
		ifFalse: [^ PopUpMenu notify: 'No changes have been made.'].

	"Remove all projects but the current one.  - saves 522k"
	ProjectView allInstancesDo: [:pv | pv controller closeAndUnscheduleNoTerminate].
	Project current setParent: Project current.
	MorphWorldView allInstancesDo: [:pv | pv topView controller closeAndUnscheduleNoTerminate].
	Wonderland removeActorPrototypesFromSystem.
	Player freeUnreferencedSubclasses.
	MorphicModel removeUninstantiatedModels.
	Utilities classPool at: #ScrapsBook put: nil.

	Smalltalk discardVMConstruction.  "755k"
	Smalltalk discardSoundSynthesis.  "544k"
	Smalltalk discardOddsAndEnds.  "227k"
	Smalltalk discardNetworking.  "234k"
	Smalltalk discard3D.  "407k"
	Smalltalk discardFFI.  "33k"
	Smalltalk discardMorphic.  "1372k"
	Symbol rehash.  "40k"
	"Above by itself saves about 4,238k"

	"Remove references to a few classes to be deleted, so that they won't leave obsolete versions around."
	FileList removeSelector: #fileIntoNewChangeSet.
	ChangeSet class compile: 'defaultName
		^ ''Changes'' ' classified: 'initialization'.
	ScreenController removeSelector: #openChangeManager.
	ScreenController removeSelector: #exitProject.
	ScreenController removeSelector: #openProject.
	ScreenController removeSelector: #viewImageImports.

	"Now delete various other classes.."
	SystemOrganization removeSystemCategory: 'Graphics-Files'.
	SystemOrganization removeSystemCategory: 'System-Object Storage'.
	Smalltalk removeClassNamed: #ProjectController.
	Smalltalk removeClassNamed: #ProjectView.
	"Smalltalk removeClassNamed: #Project."
	Smalltalk removeClassNamed: #Environment.
	Smalltalk removeClassNamed: #Component1.

	Smalltalk removeClassNamed: #FormSetFont.
	Smalltalk removeClassNamed: #FontSet.
	Smalltalk removeClassNamed: #InstructionPrinter.
	Smalltalk removeClassNamed: #ChangeSorter.
	Smalltalk removeClassNamed: #DualChangeSorter.
	Smalltalk removeClassNamed: #EmphasizedMenu.
	Smalltalk removeClassNamed: #MessageTally.

	StringHolder class removeSelector: #originalWorkspaceContents.
	CompiledMethod removeSelector: #symbolic.

	RemoteString removeSelector: #makeNewTextAttVersion.
	Utilities class removeSelector: #absorbUpdatesFromServer.
	Smalltalk removeClassNamed: #PenPointRecorder.
	Smalltalk removeClassNamed: #Path.
	Smalltalk removeClassNamed: #Base64MimeConverter.
	"Smalltalk removeClassNamed: #EToySystem. Dont bother - its very small and used for timestamps etc"
	Smalltalk removeClassNamed: #RWBinaryOrTextStream.
	Smalltalk removeClassNamed: #AttributedTextStream.
	Smalltalk removeClassNamed: #WordNet.
	Smalltalk removeClassNamed: #SelectorBrowser.

	TextStyle allSubInstancesDo:
		[:ts | ts newFontArray: (ts fontArray copyFrom: 1 to: (2 min: ts fontArray size))].
	ListParagraph initialize.
	PopUpMenu initialize.
	StandardSystemView initialize.

	Smalltalk noChanges.
	ChangeSorter classPool at: #AllChangeSets 
		put: (OrderedCollection with: Smalltalk changes).
	(Smalltalk includesKey: #Morph) "only remove if Morphic has been removed"
		ifTrue:[Smalltalk removeClassNamed: #CornerRounder.
			ScriptingSystem _ nil].
	SystemDictionary removeSelector: #majorShrink.

	[Smalltalk removeAllUnSentMessages > 0]
		whileTrue:
		[Smalltalk unusedClasses do: [:c | (Smalltalk at: c) removeFromSystem]].
	SystemOrganization removeEmptyCategories.
	Smalltalk allClassesDo: [:c | c zapOrganization].
	MethodDictionary allInstances do: [:d | d rehash].
	Smalltalk changes initialize.
	Symbol rehash.