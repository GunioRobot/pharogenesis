absorbAfter: oldVersion from: fileName
	"Read the .ix file and add to the methodVersions database.  See class comment."

	| server aUrl strm newUpdate newName prevFile classAndMethod updateID key verList new |
	server _ ServerDirectory serverInGroupNamed: group.
		"later try multiple servers"
	aUrl _ server altUrl, 'docpane/', fileName.
	strm _ HTTPSocket httpGetNoError: aUrl
		args: nil accept: 'application/octet-stream'.
	strm class == RWBinaryOrTextStream ifFalse: [^ false].

	(strm upTo: $ ) = 'External' ifFalse: [strm close. ^ false].
	newUpdate _ Integer readFrom: strm.
	newUpdate = oldVersion ifTrue: [strm close. ^ false].		"already have it"
 	strm upTo: $'.
	newName _ strm nextDelimited: $'.  strm upTo: Character cr.
	prevFile _ strm upTo: Character cr.
	"does this report on updates just after what I know?"
	oldVersion = (prevFile splitInteger first) ifFalse: [
		strm close. ^ prevFile].	"see earlier sucessor file"
	[strm atEnd] whileFalse: [
		strm upTo: $'.
		classAndMethod _ strm nextDelimited: $'.  strm next.
		updateID _ Integer readFrom: strm.
		key _ DocLibrary properStemFor: classAndMethod.
		verList _ methodVersions at: key ifAbsent: [#()].
		(verList includes: updateID) ifFalse: [
			new _ verList, (Array with: updateID with: -1 "file date seen").
			methodVersions at: key put: new]].
	strm close.
	lastUpdate _ newUpdate.
	lastUpdateName _ newName.
	^ true