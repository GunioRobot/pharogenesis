selectionAsForm

        | relativeBounds scaledBounds |
        currentSelectionMorph ifNil: [^nil].
        relativeBounds _ currentSelectionMorph bounds translateBy: self position negated.
        scaledBounds _ relativeBounds scaleBy: 1 / magnification.
        ^ self unmagnifiedForm copy: scaledBounds