releaseParagraph
	"Paragraph instantiation is lazy -- it will be created only when needed"
	self releaseEditor.
	paragraph ifNotNil:
		[paragraph _ nil].
	container ifNotNil:
		[container releaseCachedState]