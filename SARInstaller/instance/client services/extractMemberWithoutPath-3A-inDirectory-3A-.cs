extractMemberWithoutPath: aMemberOrName inDirectory: aDirectory
	"Extract aMemberOrName to its own filename, but ignore any directory paths, using aDirectory instead"
	| member |
	member _ self memberNamed: aMemberOrName.
	member ifNil: [ ^self errorNoSuchMember: aMemberOrName ].
	self zip extractMemberWithoutPath: member inDirectory: aDirectory.
	self installed: member.