extractMember: aMemberOrName toFileNamed: aFileName
	| member |
	member _ self member: aMemberOrName.
	member ifNil: [ ^nil ].
	member extractToFileNamed: aFileName