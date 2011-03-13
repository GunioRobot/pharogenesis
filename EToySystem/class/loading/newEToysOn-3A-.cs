newEToysOn: serverList
	"Return a list of fully formed URLs of update files we do not yet
have.  Go to the listed servers and look at the file 'updates.list' for the
names of the last N update files.  We look backwards for the first one we
have, and make the list from there."

	| doc list out |
	out _ OrderedCollection new.
	serverList do: [:server |
		doc _ HTTPSocket httpGet: server,'etoys.list2' 
					"Just add to contents of file 'etoys.list2', don't change its name"
				accept: 'application/octet-stream'.
		"test here for server being up"
		doc class == RWBinaryOrTextStream ifTrue:
			[list _ doc reset; contents.	"one file name per line"
			list _ Utilities extractThisVersion: list.
			^ list collect: [:nn | server, nn]].
		"Server was down, try next one"].
	PopUpMenu notify: 'All EToy servers seem to be unavailable'.
	^ out