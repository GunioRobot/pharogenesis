majorShrink    "Smalltalk majorShrink; abandonSources; lastRemoval"
	"This method throws out lots of the system that is not needed for, eg, operation in a hand-held PC.  The shrink process is being improved and, in conjunction with removeAllUnSentMessages, yields an image around 600k in size."

	self minorShrink.

	"Remove references to a few classes to be deleted, so that they won't leave obsolete versions around."
	FileList removeSelector: #fileIntoNewChangeSet.
	ChangeSet class compile: 'defaultName
		^ ''Changes'' ' classified: 'initialization'.
	ScreenController removeSelector: #openChangeManager.
	ScreenController removeSelector: #exitProject.
	ScreenController removeSelector: #openProject.
	ScreenController removeSelector: #viewGIFImports.

	"Now delete lots of classes.."
	(SystemOrganization categories select: [:c | 'Morphic*' match: c]) reverseDo:
		[:c | SystemOrganization removeSystemCategory: c].
	SystemOrganization removeSystemCategory: 'System-Network'.
	SystemOrganization removeSystemCategory: 'System-Monitoring'.
	SystemOrganization removeSystemCategory: 'Graphics-Symbols'.
	SystemOrganization removeSystemCategory: 'Graphics-Files'.
	SystemOrganization removeSystemCategory: 'Interface-Projects'.
	SystemOrganization removeSystemCategory: 'Object Storage'.
	SystemOrganization removeSystemCategory: 'System-Sound'.

	Smalltalk removeClassNamed: #Circle.
	Smalltalk removeClassNamed: #Arc.
	Smalltalk removeClassNamed: #FormSetFont.
	Smalltalk removeClassNamed: #FontSet.
	Smalltalk removeClassNamed: #InstructionPrinter.
	Smalltalk removeClassNamed: #ChangeSorter.
	Smalltalk removeClassNamed: #DualChangeSorter.
	Smalltalk removeClassNamed: #EmphasizedMenu.
	Smalltalk removeClassNamed: #MessageTally.
	Smalltalk removeClassNamed: #BitEditor.

	StringHolder class removeSelector: #originalWorkspaceContents.
	CompiledMethod removeSelector: #symbolic.
	TextConstants removeKey: #ClairVaux ifAbsent: [].  "deletes a couple of fonts"

	TextStyle allInstancesDo:
		[:ts | (ts instVarAt: 1) size > 2 ifTrue:  "Only need two fonts"
			[ts instVarAt: 1 put: ((ts instVarAt: 1) copyFrom: 1 to: 2)]].
	ListParagraph initialize.
	PopUpMenu initialize.
	StandardSystemView initialize.

	Smalltalk noChanges.
	ChangeSorter classPool at: #AllChangeSets 
		put: (OrderedCollection with: Smalltalk changes).

	[self removeAllUnSentMessages > 0] whileTrue.
	Smalltalk allClassesDo: [:c | c zapOrganization].
	Symbol rehash.
