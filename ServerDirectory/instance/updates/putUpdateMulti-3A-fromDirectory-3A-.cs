putUpdateMulti: list fromDirectory: updateDirectory
	"Put these files out as an Update on the servers of my group.  List is an array of local file names without number prefixes.  Each version of the system has its own set of update files.  'updates.list' holds the master list.  Each update is a fileIn whose name begins with a number.  See Utilities class absorbUpdatesFromServer."

	| myServers updateStrm sequence myName response restOfText seq add newNames file |
	(self checkNames: list) ifFalse: [^ nil].
	myName _ group ifNil: [self moniker] ifNotNil: [group key].
	response _ (PopUpMenu labels: 'Install update\Cancel update' withCRs)
		startUpWithCaption: 'Do you really want to broadcast ', list size printString, ' updates',
			'\to every Squeak user who updates from ' withCRs, myName, '?'.
	response = 1 ifFalse: [^ nil].	"abort"

	self openGroup.
	(myServers _ self checkServers) size = 0 ifTrue: [self closeGroup.  ^ self].
	updateStrm _ myServers first getFileNamed: 'updates.list'.
	"get last number and add 1"
	sequence _ Utilities lastUpdateNum: updateStrm.
	add _ WriteStream on: (String new: 200).
	newNames _ list collect: [:each | 
		seq _ (sequence _ sequence+1) printString.
		seq size = 1 ifTrue: [seq _ '00', seq].
		seq size = 2 ifTrue: [seq _ '0', seq].
		add nextPutAll: seq; nextPutAll: each; cr.
		seq, each].
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
	updateStrm nextPutAll: add contents; nextPutAll: restOfText.

	myServers do: [:aServer |
		list doWithIndex: [:local :ind |
			file _ updateDirectory oldFileNamed: local.
			aServer putFile: file named: (newNames at: ind) retry: true.
			file close].
		updateStrm reset.
		aServer putFile: updateStrm named: 'updates.list' retry: true.
		Transcript cr; show: 'Updates succeeded on server ', aServer moniker].
	self closeGroup.
	
	Transcript cr; show: 'Be sure to test your new update!'; cr.
	"rename the file locally"
	list with: newNames do:
		[:local :newName | updateDirectory rename: local toBe: newName].
