lastSearchString
	"Answer the last search string, initializing it to an empty string if it has not been initialized yet"

	^ currentQueryParameter ifNil: [currentQueryParameter _ 'contents']