copySelection

        | relativeBounds scaledBounds |
        currentSelectionMorph ifNil: [^ nil].
        relativeBounds _ currentSelectionMorph bounds translateBy: self position negated.
        scaledBounds _ relativeBounds scaleBy: 1 / magnification.
        FormClipboard _ (self unmagnifiedForm copy: scaledBounds).
        ^ relativeBounds