listName
	"Return something suitable for showing in lists.
	We list the manual version after a dash if it is available.
	We don't list the release name."

	^version isEmpty
		ifFalse: [self automaticVersion versionString , '-', version]
		ifTrue: [self automaticVersion versionString] 