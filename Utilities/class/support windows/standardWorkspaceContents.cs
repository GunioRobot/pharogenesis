standardWorkspaceContents
	^ self class firstCommentAt: #standardWorkspaceContents

	"Smalltalk recover: 10000.
ChangeList browseRecentLog.
ChangeList browseRecent: 2000.

Preferences editAnnotations.
Utilities reinstateDefaultFlaps. 
Preferences resetCategoryInfo

(FileStream oldFileNamed: 'Lives of the Wolves') edit.
(FileStream oldFileNamed: 'tuesdayFixes.cs') fileIn
ChangeList browseFile: 'myChanges.st'

TextStyle default fontAt: 7 put: (StrikeFont new readMacFontHex: 'Cairo 18')

StandardSystemView browseAllAccessesTo: 'maximumSize'.
StandardSystemView doCacheBits  ""restore fast windows mode in mvc""

Symbol selectorsContaining: 'rsCon'.
Smalltalk browseMethodsWhoseNamesContain: 'screen'.

Browser newOnClass: Utilities.
Browser fullOnClass: SystemDictionary.

FormView allInstances inspect.
StandardSystemView someInstance inspect.

Utilities storeTextWindowContentsToFileNamed: 'TextWindows'
Utilities reconstructTextWindowsFromFileNamed: 'TextWindows'

ScriptingSystem resetStandardPartsBin.
ScheduledControllers screenController openMorphicConstructionWorld.
ScheduledControllers screenController openMorphicWorld.

SystemOrganization categoryOfElement: #Controller. 
ParagraphEditor organization categoryOfElement: #changeEmphasis.

Cursor wait showWhile: [Sensor waitButton].

Smalltalk bytesLeft asStringWithCommas.
Symbol instanceCount. 
Time millisecondsToRun:
	[Smalltalk allCallsOn: #asOop]
MessageTally spyOn: [Smalltalk allCallsOn: #asOop].

"

"Utilities openStandardWorkspace"