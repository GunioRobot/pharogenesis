isSourceFileSuffix: suffix

	^ (FileStream sourceFileSuffixes includes: suffix) or: [suffix = '*'].
