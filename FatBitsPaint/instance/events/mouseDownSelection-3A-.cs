mouseDownSelection: evt

        lastMouse _ nil.
        currentSelectionMorph ifNotNil: [currentSelectionMorph delete. currentSelectionMorph _ nil].
        selectionAnchor _ self pointGriddedFromEvent: evt