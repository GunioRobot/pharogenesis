remove: aVersion
	"Remove aVersion from this version history."

	^self remove: aVersion ifAbsent: [self error: 'version not found'].