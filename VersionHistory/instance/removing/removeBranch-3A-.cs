removeBranch: aVersion
	"Remove aVersion and all of it's successors, providing that
	aVersion is not the first version."

	(self versionBefore: aVersion)
		ifNil: [^self error: 'version is the first version in the history'].

	versions removeAll: (self allVersionsAfter: aVersion).
	versions remove: aVersion.