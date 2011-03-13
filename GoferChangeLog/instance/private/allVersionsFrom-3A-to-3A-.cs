allVersionsFrom: currentVersion to: latestVersion
	"return nil if the current version is not part of my ancestors"
	| result |
	result := OrderedCollection new.
	result add: latestVersion.
	latestVersion breadthFirstAncestors do: [:version | version = currentVersion ifTrue: [^result] ifFalse: [result add: version] ].
	^nil