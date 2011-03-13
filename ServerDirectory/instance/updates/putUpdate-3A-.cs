putUpdate: fileStrm
	"Put this file out as an Update on the servers of my group.  Each version of the system has its own set of update files.  'updates.list' holds the master list.  Each update is a fileIn whose name begins with a number.  See Utilities class absorbUpdatesFromServer."

	| myServers updateStrm sequence newName myName response local restOfText seq |
"	(ScheduledControllers scheduledControllers detect: [:each |
		each model == Transcript] ifNone: [nil]) ifNil: [
			^ self inform: 'Please open a Transcript window, and 
then start putting out this update again.'].
"
	local _ fileStrm localName.
	(local count: [:char | char == $.]) > 1 ifTrue: [
		^ self inform: 'File name cannot have more than one period'].
	(local at: 1) isDigit ifTrue: [
		^ self inform: 'File name cannot begin with a number'].
		"later offer to strip it off and put on new number"
	(local findDelimiters: '%/* ' startingAt: 1) <= local size ifTrue: [
		^ self inform: 'File name cannot contain % / * or space'].
	myName _ group ifNil: [self moniker] ifNotNil: [group key].
	response _ (PopUpMenu labels: 'Install update\Cancel update' withCRs)
		startUpWithCaption: 'Do you really want to broadcast the file ', local, 
			'\to every Squeak user who updates from ' withCRs, myName, '?'.
	response = 1 ifFalse: [^ nil].	"abort"

	(myServers _ self checkServers) size = 0 ifTrue: [^ self].
	updateStrm _ myServers first getFileNamed: 'updates.list'.
	"get last number and add 1"
	sequence _ Utilities lastUpdateNum: updateStrm.
	seq _ (sequence+1) printString.
	seq size = 1 ifTrue: [seq _ '00', seq].
	seq size = 2 ifTrue: [seq _ '0', seq].
	newName _ seq, local.
	restOfText _ Utilities position: updateStrm 	"sets the postion!!"
			atVersion: (Smalltalk at: #EToySystem) version.
	restOfText size > 0 ifTrue: [
		response _ (PopUpMenu labels: 'Make update for my older version\Cancel update' withCRs)
			startUpWithCaption: 'This system, ', (Smalltalk at: #EToySystem) version,
				' is not the latest version'.
		response = 1 ifFalse: [^ nil].	"abort"
		].
	"append name to updates"
	(updateStrm skip: -1; next) == Character cr ifFalse: [
		updateStrm nextPut: Character cr].
	updateStrm nextPutAll: newName; nextPut: Character cr; nextPutAll: restOfText.

	myServers do: [:aServer |
		fileStrm reset.	"reopen"
		aServer putFile: fileStrm named: newName.
		updateStrm reset.
		aServer putFile: updateStrm named: 'updates.list'.
		Transcript cr; show: 'Update succeeded on server ', aServer moniker].
		
	Transcript cr; show: 'Be sure to test your new update!'; cr.
	"rename the file locally (may fail)"
	fileStrm directory rename: local toBe: newName.
