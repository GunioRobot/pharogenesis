storeOnServer
	| servers pair newVersion resp newName local folder |
	"Save to disk as an Export Segment.  Then put that file on the server I came from, as a new version.  Version is literal piece of file name.  Mime encoded and http encoded."

	self == CurrentProject ifTrue: ["exit, then do the command"
		^ self armsLengthCommand: #storeOnServer].
	"write locally"
	self exportSegment.
	(FileStream oldFileNamed: self name, '.pr') compressFile.
	"Find out what version"
	(servers _ self serverList) isEmpty 
		ifTrue: [folder _ PluggableFileList getFolderDialog openLabel:
					 'Select a folder on a server:'.
			folder ifNil: [^ self].
			servers _ Array with: folder.
			urlList _ Array with: folder realUrl, '/'.
			pair _ Array with: nil with: -1]
		ifFalse: [pair _ self class mostRecent: self name onServer: servers first].

	(newVersion _ self newVersion: pair) ifNil: [^ self].
	newName _ self name, '|', newVersion, '.pr'.
	local _ FileStream oldFileNamed: self name, '.pr.gz'.
	resp _ servers first putFile: local named: newName retry: false.
	resp ifFalse: [self inform: 'the primary server of this project seems to be down'.  ^ self].
	version _ newVersion.	"committed"

	"Later, store with same name on secondary servers.  Still can be race conditions.  All machines will go through the server list in the same order."
	"2 to: servers size do: [:aServer | aServer putFile: local named: newName]."

	"Rename disk file to be the final name"
	local reset.
	local localName = newName 
		ifFalse: [FileDirectory default rename: local localName toBe: newName]
		ifTrue: [local close].