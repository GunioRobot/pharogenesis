removeTrunk: aVersion
	"Remove aVersion and all of it's predecessors, providing there
	are no other branches stemming from the trunk.  Note, a trunk is defined
	as all versions, starting with the first version, that have only one successor."

	| tmp |
	(self versionsAfter: aVersion) size > 1 
		ifTrue: [^self error: 'version is at a fork'].

	tmp := self allVersionsBefore: aVersion.
	(tmp detect: [ :ea | (self versionsAfter: ea) size > 1 ] ifNone: [nil])
		ifNotNil: [^self error: 'not a trunk, other branches detected'].

	versions removeAll: tmp.
	versions remove: aVersion.