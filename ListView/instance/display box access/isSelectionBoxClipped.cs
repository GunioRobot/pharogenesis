isSelectionBoxClipped
        "Answer whether there is a selection and whether the selection is visible 
        on the screen."

        ^ selection ~= 0 and:
			[(self selectionBox intersects: 
                       (self clippingBox insetBy: (Rectangle left: 0 right: 0 top: 1 bottom: 0))) not]