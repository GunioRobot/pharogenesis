raiseContextMenu: characterStream 
	"AFAIK, this is never called in morphic, because a subclass overrides it. Which is good, because a ParagraphEditor doesn't know about Morphic and thus duplicates the text-editing actions that really belong in the specific application, not the controller. So the context menu this would raise is likely to be out of date."
	self yellowButtonActivity.
	^true