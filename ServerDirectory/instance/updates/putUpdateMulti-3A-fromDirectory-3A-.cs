putUpdateMulti: list fromDirectory: updateDirectory 
	"Put these files out as an Update on the servers of my group.  List is an array of local file names with or without number prefixes.  Each version of the system has its own set of update files.  'updates.list' holds the master list.  Each update is a fileIn whose name begins with a number.  See Utilities class absorbUpdatesFromServer."

	| myServers updateStrm lastNum response newNames file numStr indexPrefix listContents version versIndex seq stripped |
	(self checkNames: (list collect: "Check the names without their numbers"
		[:each | each copyFrom: (each findFirst: [:c | c isDigit not]) to: each size]))
		ifFalse: [^ nil].
	response _ (PopUpMenu labels: 'Install update\Cancel update' withCRs)
		startUpWithCaption: 'Do you really want to broadcast ', list size printString, ' updates',
			'\to every Squeak user who updates from ' withCRs, self groupName, '?'.
	response = 1 ifFalse: [^ nil].	"abort"

	self openGroup.
	indexPrefix _ (self groupName includes: $*) 
		ifTrue: [(self groupName findTokens: ' ') first]	"special for internal updates"
		ifFalse: ['']. 	"normal"
	myServers _ self checkServersWithPrefix: indexPrefix
					andParseListInto: [:x | listContents _ x].
	myServers size = 0 ifTrue: [self closeGroup.  ^ self].

	version _ SystemVersion current version.
	versIndex _ (listContents collect: [:pair | pair first]) indexOf: version.
	versIndex = 0 ifTrue:
		[self inform: 'There is no section in updates.list for your version'.
		self closeGroup.  ^ nil].	"abort"
	lastNum _ (listContents at: versIndex) last last initialIntegerOrNil.
	versIndex < listContents size ifTrue:
		[response _ (PopUpMenu labels: 'Make update for an older version\Cancel update' withCRs)
			startUpWithCaption: 'This system, ', SystemVersion current version,
				' is not the latest version'.
		response = 1 ifFalse: [self closeGroup.  ^ nil].
		numStr _ FillInTheBlank 
			request: 'Please confirm or change the starting update number' 
			initialAnswer: (lastNum+1) printString.
		lastNum _ numStr asNumber - 1].	"abort"
	"Save old copy of updates.list on local disk"
	FileDirectory default deleteFileNamed: indexPrefix , 'updates.list.bk'.
	Utilities writeList: listContents toStream: (FileStream fileNamed: indexPrefix , 'updates.list.bk').

	"Append names to updates with new sequence numbers"
	newNames _ list with: (lastNum+1 to: lastNum+list size) collect:
		[:each :num | seq _ num printString padded: #left to: 4 with: $0.
		"strip off any old seq number"
		stripped _ each copyFrom: (each  findFirst: [:c | c isDigit not]) to: each size.
		seq , stripped].
	listContents at: versIndex put:
		{version. (listContents at: versIndex) second , newNames}.

	"Write a new copy on all servers..."
	updateStrm _ ReadStream on:
		(String streamContents: [:s | Utilities writeList: listContents toStream: s]).
	myServers do:
		[:aServer |
		list doWithIndex: [:local :ind |
			file _ updateDirectory oldFileNamed: local.
			aServer putFile: file named: (newNames at: ind) retry: true.
			file close].
		updateStrm reset.
		aServer putFile: updateStrm named: indexPrefix , 'updates.list' retry: true.
		Transcript show: 'Update succeeded on server ', aServer moniker; cr].
	self closeGroup.

	Transcript cr; show: 'Be sure to test your new update!'; cr.
	"rename the file locally"
	list with: newNames do:
		[:local :newName | updateDirectory rename: local toBe: newName].