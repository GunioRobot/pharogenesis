newUpdatesOn: serverList special: indexPrefix throughNumber: aNumber
	"Return a list of fully formed URLs of update files we do not yet have.  Go to the listed servers and look at the file 'updates.list' for the names of the last N update files.  We look backwards for the first one we have, and make the list from there.  tk 9/10/97
	No updates numbered higher than aNumber (if it is not nil) are returned " 

	| existing doc list out ff raw char maxNumber itsNumber |
	maxNumber _ aNumber ifNil: [99999].
	out _ OrderedCollection new.
	existing _ SystemVersion current updates.
	serverList do: [:server |
		doc _ HTTPClient httpGet: 'http://' , server,indexPrefix,'updates.list'.
		
		"test here for server being up"
		doc class == RWBinaryOrTextStream ifTrue:
			[raw _ doc reset; contents.	"one file name per line"
			list _ self extractThisVersion: raw.
			list reverseDo: [:fileName |
				ff _ (fileName findTokens: '/') last.	"allow subdirectories"
				itsNumber _ ff initialIntegerOrNil. 
				(existing includes: itsNumber)
					ifFalse:
						[
						(itsNumber == nil or: [itsNumber <= maxNumber])
							ifTrue:
								[out addFirst: 'http://' , server, fileName]]
					ifTrue: [^ out]].
			((out size > 0) or: [char _ doc reset; skipSeparators; next.
				(char == $*) | (char == $#)]) ifTrue:
					[^ out "we have our list"]].	"else got error msg instead of file"
		"Server was down, try next one"].
	self inform: 'All code update servers seem to be unavailable'.
	^ out