saveIndexOfOnly: aPage
	"Modify the index of this book on a server.  Read the index, modify the entry for just this page, and write back.  See saveIndexOnURL. (page file names must be unique even if they live in different directories.)"

	| mine sf remoteFile strm remote pageURL num pre index after dict allText allTextUrls fName |
	mine _ self valueOfProperty: #url.
	mine ifNil: [^ self saveIndexOnURL].
	Cursor wait showWhile: [strm _ (ServerFile new fullPath: mine)].
	strm ifNil: [^ self saveIndexOnURL].
	strm isString ifTrue: [^ self saveIndexOnURL].
	strm exists ifFalse: [^ self saveIndexOnURL].	"write whole thing if missing"
	strm _ strm asStream.
	strm isString ifTrue: [^ self saveIndexOnURL].
	remote _ strm fileInObjectAndCode.
	dict _ remote first.
	allText _ dict at: #allText ifAbsent: [nil].	"remote, not local"
	allTextUrls _ dict at: #allTextUrls ifAbsent: [nil].
	allText size + 1 ~= remote size ifTrue: [self error: '.bo size mismatch.  Please tell Ted what you just did to this book.' translated].


	(pageURL _ aPage url) ifNil: [self error: 'just had one!' translated].
	fName _ pageURL copyAfterLast: $/.
	2 to: remote size do: [:ii | 
		((remote at: ii) url findString: fName startingAt: 1 
						caseSensitive: false) > 0 ifTrue: [index _ ii].	"fast"
		(remote at: ii) xxxReset].
	index ifNil: ["new page, what existing page does it follow?"
		num _ self pageNumberOf: aPage.
		1 to: num-1 do: [:ii | (pages at: ii) url ifNotNil: [pre _ (pages at: ii) url]].
		pre ifNil: [after _ remote size+1]
			ifNotNil: ["look for it on disk, put me after"
				pre _ pre copyAfterLast: $/.
				2 to: remote size do: [:ii | 
					((remote at: ii) url findString: pre startingAt: 1 
								caseSensitive: false) > 0 ifTrue: [after _ ii+1]].
				after ifNil: [after _ remote size+1]].
		remote _ remote copyReplaceFrom: after to: after-1 with: #(1).
		allText ifNotNil: [
			dict at: #allText put: (allText copyReplaceFrom: after-1 to: after-2 with: #(())).
			dict at: #allTextUrls put: (allTextUrls copyReplaceFrom: after-1 to: after-2 with: #(()))].
		index _ after].

	remote at: index put: (aPage sqkPage copyForSaving).

	(dict at: #modTime ifAbsent: [0]) < Time totalSeconds ifTrue:
		[dict at: #modTime put: Time totalSeconds].
	allText ifNotNil: [
		(dict at: #allText) at: index-1 put: (aPage allStringsAfter: nil).
		(dict at: #allTextUrls) at: index-1 put: pageURL].

	sf _ ServerDirectory new fullPath: mine.
	Cursor wait showWhile: [
		remoteFile _ sf fileNamed: mine.
		remoteFile fileOutClass: nil andObject: remote.
		"remoteFile close"].
