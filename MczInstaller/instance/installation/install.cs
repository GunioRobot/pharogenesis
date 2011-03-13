install
	| sources |
	zip _ ZipArchive new.
	zip readFrom: stream.
	self checkDependencies ifFalse: [^false].
	self recordVersionInfo.
	sources _ (zip membersMatching: 'snapshot/*') 
				asSortedCollection: [:a :b | a fileName < b fileName].
	sources do: [:src | self installMember: src].