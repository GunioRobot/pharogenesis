newUpdatesOn: serverList special: indexPrefix throughNumber: aNumber
	"Return a list of fully formed URLs of update files we do not yet have.  Go to the listed servers and look at the file 'updates.list' for the names of the last N update files.  We look backwards for the first one we have, and make the list from there.  tk 9/10/97
	No updates numbered higher than aNumber (if it is not nil) are returned " 

	| existing doc list out ff raw char maxNumber itsNumber |
	maxNumber := aNumber ifNil: [99999].
	out := OrderedCollection new.
	existing := SystemVersion current updates.
	serverList do: [:server |
		doc := HTTPClient httpGet: 'http://' , server,indexPrefix,'updates.list'.
		"test here for server being up"
		doc class == RWBinaryOrTextStream ifTrue:
			[raw := doc reset; contents.	"one file name per line"
			list := self extractThisVersion: raw.
			list reverseDo: [:fileName |
				ff := (fileName findTokens: '/') last.	"allow subdirectories"
				itsNumber := ff initialIntegerOrNil. 
				(existing includes: itsNumber)
					ifFalse:
						[
						(itsNumber isNil or: [itsNumber <= maxNumber])
							ifTrue:
								[out addFirst: 'http://' , server, fileName]]
					ifTrue: [^ out]].
			((out size > 0) or: [char := doc reset; skipSeparators; next.
				(char == $*) | (char == $#)]) ifTrue:
					[^ out "we have our list"]].	"else got error msg instead of file"
		"Server was down, try next one"].
	self inform: 'All code update servers seem to be unavailable'.
	^ out