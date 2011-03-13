contentsAsIs: stringOrText
	"Accept new text contents with line breaks only as in the text.
	Fit my width and height to the result."
	wrapFlag _ false.
	container ifNotNil: [container fillsOwner ifTrue: [wrapFlag _ true]].
	self newContents: stringOrText