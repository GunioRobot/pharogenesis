removeMember: aMemberOrName
	| member |
	member _ self member: aMemberOrName.
	member ifNotNil: [ members remove: member ].
	^member