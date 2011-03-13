exportUpdatesExcept: skipList 
	"Into the section of updates.list corresponding to this version,
	copy all the fileNames in the named updates.list for this group
	that are more recently numbered."
	"
		(ServerDirectory serverInGroupNamed: 'Disney Internal Updates*')
			exportUpdatesExcept: #(3959).
"
	| myServers updateStrm response seq indexPrefix listContents version versIndex lastNum expContents expVersIndex additions |
	self openGroup.
	indexPrefix := (self groupName includes: $*) 
		ifTrue: 
			[ (self groupName findTokens: ' ') first	"special for internal updates" ]
		ifFalse: [ '' ].	"normal"
	myServers := self 
		checkServersWithPrefix: indexPrefix
		andParseListInto: [ :x | listContents := x ].
	myServers size = 0 ifTrue: 
		[ self closeGroup.
		^ self ].
	version := SystemVersion current version.
	versIndex := (listContents collect: [ :pair | pair first ]) indexOf: version.
	versIndex = 0 ifTrue: 
		[ self inform: 'There is no section in updates.list for your version'.
		self closeGroup.
		^ nil ].	"abort"
	versIndex < listContents size ifTrue: 
		[ response := UIManager default 
			chooseFrom: #(
					'Make update from an older version'
					'Cancel update'
				)
			title: 'This system, ' , SystemVersion current version , ' is not the latest version'.
		response = 1 ifFalse: 
			[ self closeGroup.
			^ nil ] ].	"abort"

	"Get the old export updates.list."
	expContents := Utilities parseListContents: (myServers first getFileNamed: 'updates.list').
	expVersIndex := (expContents collect: [ :pair | pair first ]) indexOf: version.
	expVersIndex = 0 ifTrue: 
		[ self inform: 'There is no section in updates.list for your version'.
		self closeGroup.
		^ nil ].	"abort"
	lastNum := (expContents at: expVersIndex) last isEmpty 
		ifTrue: [ 0	"no checking if the current list is empty" ]
		ifFalse: [ (expContents at: expVersIndex) last last initialIntegerOrNil ].

	"Save old copy of updates.list on local disk"
	FileDirectory default deleteFileNamed: 'updates.list.bk'.
	Utilities 
		writeList: expContents
		toStream: (FileStream fileNamed: 'updates.list.bk').

	"Append all fileNames in my list that are not in the export list"
	additions := OrderedCollection new.
	(listContents at: versIndex) last do: 
		[ :fileName | 
		seq := fileName initialIntegerOrNil.
		(seq > lastNum and: [ (skipList includes: seq) not ]) ifTrue: [ additions addLast: fileName ] ].
	expContents 
		at: expVersIndex
		put: { 
				version.
				((expContents at: expVersIndex) last , additions)
			 }.
	(self confirm: 'Do you really want to export ' , additions size printString , ' recent updates?') ifFalse: 
		[ self closeGroup.
		^ nil ].	"abort"

	"Write a new copy of updates.list on all servers..."
	updateStrm := (String streamContents: 
		[ :s | 
		Utilities 
			writeList: expContents
			toStream: s ]) readStream.
	myServers do: 
		[ :aServer | 
		updateStrm reset.
		aServer 
			putFile: updateStrm
			named: 'updates.list'
			retry: true.
		Transcript
			show: 'Update succeeded on server ' , aServer moniker;
			cr ].
	self closeGroup.
	Transcript
		cr;
		show: 'Be sure to test your new update!';
		cr