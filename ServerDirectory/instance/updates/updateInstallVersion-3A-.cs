updateInstallVersion: newVersion
	"For each server group, ask whether we want to put the new version marker (#Squeak2.3) at the end of the file.  Current version of Squeak must be the old one when this is done.
	ServerDirectory new updateInstallVersion: 'Squeak2.3'      "

	| myServers updateStrm names choice |
[names _ ServerDirectory groupNames asSortedArray.
choice _ (SelectionMenu labelList: names selections: names) startUp.
choice == nil] whileFalse: [
	myServers _ (ServerDirectory groupNamed: choice) checkServers.
	myServers size = 0 ifTrue: [self inform: 'checkServers failed on one of those'].
	updateStrm _ myServers first getFileNamed: 'updates.list'.

	Utilities position: updateStrm 	"checks for current OLD version"
			atVersion: (Smalltalk at: #EToySystem) version.	
	
	"append name to updates"
	updateStrm setToEnd.
	(updateStrm skip: -1; next) == Character cr ifFalse: [
		updateStrm nextPut: Character cr].
	updateStrm nextPutAll: '#', newVersion; nextPut: Character cr.

	myServers do: [:aServer |
		updateStrm reset.
		aServer putFile: updateStrm named: 'updates.list' retry: true.
		Transcript cr; show: 'Update.list written on server ', aServer moniker].
		
	]