initialize
	[self new register] on: MessageNotUnderstood do: [].
	SyntaxMorph class removeSelector: #initialize.
	SyntaxMorph removeSelector: #allSpecs.
	EToyVocabulary removeSelector: #morphClassesDeclaringViewerAdditions.
	SyntaxMorph clearAllSpecs.
	Vocabulary initialize.
