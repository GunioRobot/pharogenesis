extractMemberWithoutPath: aMemberOrName inDirectory: dir
	| member |
	member _ self member: aMemberOrName.
	member ifNil: [ ^nil ].
	member extractToFileNamed: (FileDirectory localNameFor: member localFileName) inDirectory: dir