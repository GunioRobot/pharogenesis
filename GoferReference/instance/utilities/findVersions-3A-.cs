findVersions: aBlock
	"Answer a sorted array of version references that match aBlock."

	| versions |
	versions := SortedCollection new.
	self repositories do: [ :repo |
		(GoferVersionCache versionsIn: repo) do: [ :version |
			(aBlock value: version)
				ifTrue: [ versions add: version ] ] ].
	^ versions asArray