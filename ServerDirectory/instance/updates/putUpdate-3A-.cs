putUpdate: fileStrm
	"Put this file out as an Update on the servers of my group.  Use the 'Ted' convention for updates.  Each version of the system has its own set of update files.  'updates.list' holds the master list.  Each update is a fileIn whose name begins with a number.  See Utilities class absorbUpdatesFromServer."

	| myServers updateStrm sequence newName myName response local |
	local _ fileStrm localName.
	(local count: [:char | char == $.]) > 1 ifTrue: [
		^ self inform: 'File name cannot have more than one period'].
	(local findDelimiters: '%/* ' startingAt: 1) <= local size ifTrue: [
		^ self inform: 'File name cannot contain % / * or space'].
	myServers _ group ifNil: [myName _ self moniker.  Array with: self] 
			ifNotNil: [myName _ group key.  group value].
	response _ (PopUpMenu labels: 'Install update\Cancel update' withCRs)
		startUpWithCaption: 'Do you really want to broadcast the file ', local, 
			'\to every Squeak user who updates from ' withCRs, myName, '?'.
	response = 1 ifFalse: [^ nil].	"abort"

	updateStrm _ self getFileNamed: 'updates.list'.
	"get last number and add 1"
	sequence _ Utilities lastUpdateNum: updateStrm.	"and warn if not current version"
	sequence ifNil: [^ self].	"abort update of wrong sys version"
	newName _ (sequence+1) printString, local.
	"append name to updates"
	(updateStrm setToEnd; skip: -1; next) == Character cr ifFalse: [
		updateStrm nextPut: Character cr].
	updateStrm nextPutAll: newName; nextPut: Character cr.

	myServers do: [:aServer |
		fileStrm reset.	"reopen"
		aServer putFile: fileStrm named: newName.
		updateStrm reset.
		aServer putFile: updateStrm named: 'updates.list'.
		self inform: 'Update succeeded on server ', aServer moniker].
		
	self inform: 'Be sure to test your new update!'.
	"rename the file locally (may fail)"
	fileStrm directory rename: local toBe: newName.
