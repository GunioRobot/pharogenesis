blankCopyOf: aRectangle scaledBy: scale

        | newForm |
        newForm _ self class extent: (aRectangle extent * scale) truncated depth: depth.
        colors ifNotNil: [newForm colors: colors copy].
        ^ newForm