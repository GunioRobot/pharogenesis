currentQueryParameter
	"Answer the current query parameter"

	^ currentQueryParameter ifNil: [currentQueryParameter _ 'contents']