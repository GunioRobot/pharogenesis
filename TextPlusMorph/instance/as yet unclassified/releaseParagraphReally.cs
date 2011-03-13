releaseParagraphReally
	"Paragraph instantiation is lazy -- it will be created only when needed"

	editor ifNotNil: [
		self selectionChanged.
		self paragraph selectionStart: nil selectionStop: nil.
		editor _ nil].
	paragraph ifNotNil: [paragraph _ nil].
	container ifNotNil: [container releaseCachedState]