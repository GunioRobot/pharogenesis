standardWorkspaceContents
	^ self class firstCommentAt: #standardWorkspaceContents

	"Smalltalk recover: 5000.
(FileStream oldFileNamed: 'DryRot.cs') edit.
(FileStream oldFileNamed: 'change.cs') fileIn
ChangeList browseFile: 'Elvis.st'

TextStyle default fontAt: 7 put: (StrikeFont new readMacFontHex: 'Cairo 18')

InputState browseAllAccessesTo: 'deltaTime'.
StandardSystemView doCacheBits  ""restore fast windows mode""

Symbol selectorsContaining: 'rsCon'.
Smalltalk browseMethodsWhoseNamesContain: 'screen'.

Browser newOnClass: Utilities.
BrowserView browseFullForClass: ControlManager.

FormView allInstances inspect.
ScrollController someInstance inspect

SystemOrganization categoryOfElement: #Controller. 
Component organization categoryOfElement: #contentView .

ChangeList browseRecentLog.
ChangeList browseRecent: 2000.

StringHolderView openSystemWorkspace. ""edit shared sys workspace""
Cursor wait showWhile: [Sensor waitButton].

Smalltalk spaceLeft.
Symbol instanceCount. 
Time millisecondsToRun:
	[Smalltalk allCallsOn: #asOop]
MessageTally spyOn: [Smalltalk allCallsOn: #asOop].

"