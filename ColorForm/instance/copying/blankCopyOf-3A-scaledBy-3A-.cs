blankCopyOf: aRectangle scaledBy: scale

        | newForm |
        newForm _ super blankCopyOf: aRectangle scaledBy: scale.
        colors ifNotNil: [newForm colors: colors copy].
        ^ newForm