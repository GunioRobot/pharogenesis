extractThisVersion: list
	"Pull out the part of the list that applies to this version."

	| listContents version versIndex |
	listContents := self parseListContents: list.
	version := SystemVersion current version.
	versIndex := (listContents collect: [:pair | pair first]) indexOf: version.
	versIndex = 0 ifTrue: [^ Array new].		"abort"
	^ (listContents at: versIndex) last