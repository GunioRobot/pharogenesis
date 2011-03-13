previewEToysOn: serverList
	"Return a list of fully formed URLs of etoy files we do not yet
have.  Go to the listed servers and look at the file 'etoyPreview.list' for the
names of this version's etoy files."

	| doc list out |
	(Preferences valueOfFlag: #showDevelopersEToys) ifFalse: [^ ''].
	out _ OrderedCollection new.
	serverList do: [:server |
		doc _ HTTPSocket httpGet: server,'etoyPreview.list' 
				accept: 'application/octet-stream'.
		"test here for server being up"
		doc class == RWBinaryOrTextStream ifTrue:
			[list _ doc reset; contents.	"one file name per line"
			list _ Utilities extractThisVersion: list.
			^ list collect: [:nn | server, nn]].
		"Server was down, try next one"].
	PopUpMenu notify: 'All EToy servers seem to be unavailable'.
	^ out