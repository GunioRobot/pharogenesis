icon
	"Answer a form to be used as icon"
	^ Preferences visualExplorer
		ifTrue: [item iconOrThumbnailOfSize: 16]
		ifFalse: [nil]