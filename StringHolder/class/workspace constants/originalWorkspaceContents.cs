originalWorkspaceContents 
	^ self class firstCommentAt: #originalWorkspaceContents


	"			 Smalltalk-80
			 August 1st, 1985
  Copyright (c) 1981, 1982 Xerox Corp.
 Copyright (c) 1985 Apple Computer, Inc.
		   All rights reserved.

Changes and Files
Smalltalk noChanges.
Smalltalk condenseChanges
DisplayScreen removeFromChanges.
Smalltalk changes asSortedCollection
Smalltalk browseChangedMessages
(FileStream fileNamed: 'changes.st') fileOutChanges.
FileStream fileNamed: 'PenChanges.st') fileOutChangesFor: Pen.
(FileStream oldFileNamed: 'Toothpaste.st') fileIn.
(FileStream fileNamed: 'Hello') edit.
FileDirectory filesMatching: '*.st'

Inquiry
InputState browseAllAccessesTo: 'deltaTime'.
Smalltalk browseAllCallsOn: #isEmpty.
Smalltalk browseAllImplementorsOf: #includes:
Smalltalk browseAllCallsOn:
	(Smalltalk associationAt: #Mac)
Smalltalk browseAllCallsOn:
	(Cursor classPool associationAt: #ReadCursor).
Smalltalk browseAllCallsOn:
	(Undeclared associationAt: #Disk)
Smalltalk browseAllMethodsInCategory: #examples
(Smalltalk collectPointersTo: StrikeFont someInstance) inspect.
Smalltalk garbageCollect.
FileStream instanceCount 4
FormView allInstances inspect.
Smalltalk browse:  Random

HouseCleaning
Undeclared _ Dictionary new.
Undeclared keys
Undeclared associationsDo:
	[:assn | Smalltalk browseAllCallsOn: assn]
(Object classPool at: #DependentsFields) keys
(Object classPool at: #DependentsFields) keysDo: 
	[:each | (each isKindOf: DisplayText)
		ifTrue: [each release]]
Transcript clear.
Smalltalk allBehaviorsDo: ""remove old do it code""
	[:class | class removeSelector: #DoIt; 
			removeSelector: #DoItIn:].
Smalltalk removeKey: #GlobalName.
Smalltalk declare: #GlobalName
	from: Undeclared.

Globals
Names in Smalltalk other than Classes and Pools:
	Display -- a DisplayScreen
	Processor --  a ProcessorScheduler 
	ScheduledControllers -- a ControlManager
	Sensor -- an InputSensor
	Transcript -- a TextCollector
	SourceFiles -- Array of FileStreams
	SystemOrganization -- a SystemOrganizer
	StartUpList -- an OrderedCollection
	ShutDownList -- an OrderedCollection
Variable Pools (Dictionaries)
	Smalltalk 
	FilePool
	BitMaskPool
	TextConstants
	Undeclared

System Files
SourceFiles _ Array				""open source files""
	with: (FileStream oldFileNamed:
				Smalltalk sourcesName) readOnly
	with: (FileStream oldFileNamed:
				Smalltalk changesName).
(SourceFiles at: 1) close.			""close source files""
(SourceFiles at: 2) close.
SourceFiles _ Array new: 2.

Measurements
Smalltalk spaceLeft '16381 objects, 104308 words.'
Symbol instanceCount 3697
BlockContext instanceCount 14
Time millisecondsToRun:
	[Smalltalk allCallsOn: #asOop] 11504
MessageTally spyOn: [Smalltalk allCallsOn: #asOop].

Crash recovery
Smalltalk recover: 5000."

"This is the string found in the image, Feb 91"