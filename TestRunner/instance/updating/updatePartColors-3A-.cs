updatePartColors: aColor
        passFailText isMorph
                ifTrue:
                        [passFailText color: aColor.
                        detailsText color: aColor]
                ifFalse:
                        [passFailText insideColor: aColor.
                        detailsText insideColor: aColor]