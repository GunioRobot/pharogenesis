contentsOf: aMemberOrName
	| member |
	member _ self member: aMemberOrName.
	member ifNil: [ ^nil ].
	^member contents