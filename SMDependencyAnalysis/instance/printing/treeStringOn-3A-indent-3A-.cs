treeStringOn: stream indent: level
	"Print the tree
	structure of all possible scenarios."

	| i |
	i := self indent: level.
	stream nextPutAll: i, 'Wanted:'; cr.
	wantedReleases do: [:r |
		stream nextPutAll: i ,'  ' , r packageNameWithVersion;cr].
	stream nextPutAll: i, 'Tricky:'; cr.
	trickyReleases do: [:r |
		stream nextPutAll: i ,'  ' , r packageNameWithVersion;cr].
	stream cr.
	subAnalysises ifNotNil: [
		subAnalysises do: [:sub | sub treeStringOn: stream indent: level + 1]]