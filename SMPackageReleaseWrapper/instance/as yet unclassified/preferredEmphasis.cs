preferredEmphasis
	"Render the release as bold if it is published."

	^item isPublished ifTrue: [1] ifFalse: [nil]