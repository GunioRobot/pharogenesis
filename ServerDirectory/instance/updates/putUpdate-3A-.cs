putUpdate: fileStrm 
	"Put this file out as an Update on the servers of my group.  Each version of the system has its own set of update files.  'updates.list' holds the master list.  Each update is a fileIn whose name begins with a number.  See Utilities class readServerUpdatesThrough:saveLocally:updateImage:."

	| myServers updateStrm sequence newName myName response local restOfText seq fileContents |
"	(ScheduledControllers scheduledControllers detect: [:each |
		each model == Transcript] ifNone: [nil]) ifNil: [
			^ self inform: 'Please open a Transcript window, and 
then start putting out this update again.'].
"
	local _ fileStrm localName.
	fileStrm size = 0
		ifTrue: [^ self inform: 'That file has zero bytes!  May have a new name.'].
	fileContents _ fileStrm contentsOfEntireFile.
	(fileContents includes: Character linefeed)
		ifTrue: [self notify: 'That file contains linefeeds.
Proceed if you know that this is okay (e.g. the file contains raw binary data).'].
	fileStrm reset.
	(self checkNames: (Array with: local)) ifFalse: [^ nil].	"illegal characters"
	myName _ group ifNil: [self moniker] ifNotNil: [group key].
	response _ (PopUpMenu labels: 'Install update\Cancel update' withCRs)
		startUpWithCaption: 'Do you really want to broadcast the file ', local, 
			'\to every Squeak user who updates from ' withCRs, myName, '?'.
	response = 1 ifFalse: [^ nil].	"abort"

	self openGroup.
	(myServers _ self checkServers) size = 0 ifTrue: [self closeGroup.  ^ self].
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
		response = 1 ifFalse: [self closeGroup.  ^ nil].	"abort"
		].
	"append name to updates"
	(updateStrm skip: -1; next) == Character cr ifFalse: [
		updateStrm nextPut: Character cr].
	updateStrm nextPutAll: newName; nextPut: Character cr; nextPutAll: restOfText.

	myServers do: [:aServer |
		fileStrm reset.	"reopen"
		aServer putFile: fileStrm named: newName retry: true.
		updateStrm reset.
		aServer putFile: updateStrm named: 'updates.list' retry: true.
		Transcript cr; show: 'Update succeeded on server ', aServer moniker].
	self closeGroup.
		
	Transcript cr; show: 'Be sure to test your new update!'; cr.
	"rename the file locally (may fail)"
	fileStrm directory rename: local toBe: newName.
