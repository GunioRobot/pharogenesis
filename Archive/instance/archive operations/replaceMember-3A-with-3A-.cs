replaceMember: aMemberOrName with: newMember
	| member |
	member _ self member: aMemberOrName.
	member ifNotNil: [ members replaceAll: member with: newMember ].
	^member