extractMember: aMemberOrName
	| member |
	member _ self member: aMemberOrName.
	member ifNil: [ ^nil ].
	member extractToFileNamed: member localFileName inDirectory: FileDirectory default.