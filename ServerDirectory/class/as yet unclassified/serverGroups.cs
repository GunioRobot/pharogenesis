serverGroups
	"Return all registered groups of servers (include individual servers not in any group).  Each is an association (name -> server)"

	| grp set |
	set _ Set new.
	Smalltalk associationsDo: [:ass |
		(ass value isKindOf: self) ifTrue: [
			grp _ ass value group.
			grp ifNil: [set add: ass]	"assoc"
				ifNotNil: [ass value == grp value first ifTrue: [set add: ass]]]].
	^ (set asOrderedCollection) collect: [:each | 
				Association key: each value groupName value: each value].
