searchString
	"Answer the current searchString, initializing it if need be"
	searchString isEmptyOrNil ifTrue:
		[searchString _ ''].
	^ searchString