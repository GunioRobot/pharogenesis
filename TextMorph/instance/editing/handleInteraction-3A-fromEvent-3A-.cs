handleInteraction: interactionBlock fromEvent: evt
	"Perform the changes in interactionBlock, noting any change in selection
	and possibly a change in the size of the paragraph (ar 9/22/2001 - added for TextPrintIts)"
	"Also couple ParagraphEditor to Morphic keyboard events"
	| oldEditor oldParagraph oldText |
	self editor sensor: (KeyboardBuffer new startingEvent: evt).
	oldEditor _ editor.
	oldParagraph _ paragraph.
	oldText _ oldParagraph text copy.

	self selectionChanged.  "Note old selection"

		interactionBlock value.

	(oldParagraph == paragraph) ifTrue:[
		"this will not work if the paragraph changed"
		editor _ oldEditor.     "since it may have been changed while in block"
	].
	self selectionChanged.  "Note new selection"
	(oldText = paragraph text and: [ oldText runs = paragraph text runs ])
		ifFalse:[ self updateFromParagraph ].
	self setCompositionWindow.