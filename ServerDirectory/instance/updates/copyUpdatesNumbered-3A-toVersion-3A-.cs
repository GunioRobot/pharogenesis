copyUpdatesNumbered: selectList toVersion: otherVersion 
	"Into the section of updates.list corresponding to otherVersion,
	copy all the fileNames from this version matching the selectList."
	"
		(ServerDirectory serverInGroupNamed: 'Disney Internal Updates*')
			copyUpdatesNumbered: #(4411 4412) to version: 'Squeak3.1beta'.
"
	| myServers updateStrm seq indexPrefix listContents version versIndex lastNum otherVersIndex additions outOfOrder |
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
	otherVersIndex := (listContents collect: [ :pair | pair first ]) indexOf: otherVersion.
	otherVersIndex = 0 ifTrue: 
		[ self inform: 'There is no section in updates.list for the target version'.
		self closeGroup.
		^ nil ].	"abort"
	versIndex < listContents size ifTrue: 
		[ (self confirm: 'This system, ' , version , ' is not the latest version.\OK to copy updates from that old version?' withCRs) ifFalse: 
			[ self closeGroup.
			^ nil ] ].	"abort"

	"Append all fileNames in my list that are not in the export list"
	additions := OrderedCollection new.
	outOfOrder := OrderedCollection new.
	lastNum := (listContents at: otherVersIndex) last isEmpty 
		ifTrue: [ 0	"no checking if the current list is empty" ]
		ifFalse: [ (listContents at: otherVersIndex) last last initialIntegerOrNil ].
	(listContents at: versIndex) last do: 
		[ :fileName | 
		seq := fileName initialIntegerOrNil.
		(selectList includes: seq) ifTrue: 
			[ seq > lastNum 
				ifTrue: [ additions addLast: fileName ]
				ifFalse: [ outOfOrder addLast: seq ] ] ].
	outOfOrder isEmpty ifFalse: 
		[ UIManager default inform: 'Updates numbered ' , outOfOrder asArray printString , ' are out of order.\ The last update in ' withCRs , otherVersion , ' is ' , lastNum printString , '.\No update will take place.' withCRs.
		self closeGroup.
		^ nil ].	"abort"

	"Save old copy of updates.list on local disk"
	FileDirectory default deleteFileNamed: indexPrefix , 'updates.list.bk'.
	Utilities 
		writeList: listContents
		toStream: (FileStream fileNamed: indexPrefix , 'updates.list.bk').

	"Write a new copy of updates.list on all servers..."
	listContents 
		at: otherVersIndex
		put: { 
				otherVersion.
				((listContents at: otherVersIndex) last , additions)
			 }.
	updateStrm := (String streamContents: 
		[ :s | 
		Utilities 
			writeList: listContents
			toStream: s ]) readStream.
	myServers do: 
		[ :aServer | 
		updateStrm reset.
		aServer 
			putFile: updateStrm
			named: indexPrefix , 'updates.list'
			retry: true.
		Transcript
			show: 'Update succeeded on server ' , aServer moniker;
			cr ].
	self closeGroup.
	Transcript
		cr;
		show: 'Be sure to test your new update!';
		cr