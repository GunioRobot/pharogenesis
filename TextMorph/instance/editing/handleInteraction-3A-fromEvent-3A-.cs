handleInteraction: interactionBlock fromEvent: evt
        | oldEditor oldParagraph |
        "Perform the changes in interactionBlock, noting any change in selection"

        "Also couple ParagraphEditor to Morphic keyboard events"
        self editor sensor: (KeyboardBuffer new startingEvent: evt).
        oldEditor _ editor.
        oldParagraph _ paragraph.
        self selectionChanged.  "Note old selection"

                interactionBlock value.

        oldParagraph == paragraph ifTrue: [     "this will not work if the paragraph changed"
                editor _ oldEditor.     "since it may have been changed while in block"
        ].
        self selectionChanged.  "Note new selection"