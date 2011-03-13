updateInstallVersion: newVersion 
	"For each server group, ask whether we want to put the new version marker (eg 'Squeak2.3') at the end of the file.  Current version of Squeak must be the old one when this is done.
		ServerDirectory new updateInstallVersion: 'Squeak9.9test'
"
	| myServers updateStrm names choice indexPrefix listContents version versIndex |
	
	[ names := ServerDirectory groupNames asSortedArray.
	choice := UIManager default chooseFrom: names values: names.
	choice == nil ] whileFalse: 
		[ indexPrefix := (choice endsWith: '*') 
			ifTrue: [ (choice findTokens: ' ') first	"special for internal updates" ]
			ifFalse: [ '' ].	"normal"
		myServers := (ServerDirectory serverInGroupNamed: choice) 
			checkServersWithPrefix: indexPrefix
			andParseListInto: [ :x | listContents := x ].
		myServers size = 0 ifTrue: [ ^ self ].
		version := SystemVersion current version.
		versIndex := (listContents collect: [ :pair | pair first ]) indexOf: version.
		versIndex = 0 ifTrue: 
			[ ^ self inform: 'There is no section in updates.list for your version' ].	"abort"

		"Append new version to updates following my version"
		listContents := listContents 
			copyReplaceFrom: versIndex + 1
			to: versIndex
			with: {  {  newVersion. {   }  }  }.
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
				named: indexPrefix , 'updates.list'.
			Transcript
				cr;
				show: indexPrefix , 'updates.list written on server ' , aServer moniker ].
		self closeGroup ]