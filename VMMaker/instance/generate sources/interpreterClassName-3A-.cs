interpreterClassName: aString

	| tmp |
	interpreterClassName _ aString.
	tmp _ Smalltalk at: aString asSymbol ifAbsent: [nil].
	(tmp isNil or: [tmp isBehavior not]) ifTrue:
		[self invalidClassName].