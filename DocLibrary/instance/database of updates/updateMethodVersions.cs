updateMethodVersions
	"See if any new updates have occurred, and put their methods into the database."

	| indexFile list result |
	indexFile _ 'latest.ix'.
	list _ OrderedCollection new.
	[result _ self absorbAfter: lastUpdate from: indexFile.
	"boolean if succeeded, or we are up to date, or server not available"
	 result isString] whileTrue: [
		"result is the prev file name"
		list addFirst: indexFile.
		indexFile _ result].
	list do: [:aFile | self absorbAfter: lastUpdate from: aFile].
		"should always work this time"
