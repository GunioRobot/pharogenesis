versionBefore: aVersion

	"Answer the version immediately preceeding aVersion."

	| tmp |
	(aVersion > '1' asVersion) ifFalse: [^nil].
	(versions includes: (tmp := aVersion previous)) ifFalse: [^nil].
	^tmp