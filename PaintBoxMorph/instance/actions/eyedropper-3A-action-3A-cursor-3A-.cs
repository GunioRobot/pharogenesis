eyedropper: aButton action: aSelector cursor: aCursor 
        "Take total control and pick up a color!!"
        | pt feedbackColor |
        aButton state: #on.
        tool ifNotNil: [tool state: #off].
        currentCursor _ aCursor.
        self activeHand
                showTemporaryCursor: currentCursor 
                hotSpotOffset: 6 negated @ 4 negated.    "<<<< the form was changed a bit??"
        feedbackColor _ Display colorAt: Sensor cursorPoint.
        self addMorphFront: colorMemory.
        "Full color picker"
        [Sensor anyButtonPressed]
                whileFalse: 
                        [pt _ Sensor cursorPoint.

                        "deal with the fact that 32 bit displays may have garbage in the alpha bits"
                        feedbackColor _ Display depth = 32 ifTrue: [
                                Color colorFromPixelValue: ((Display pixelValueAt: pt)
														bitOr: 16rFF000000) depth: 32
                        ] ifFalse: [
                                Display colorAt: pt
                        ].

                        "the hand needs to be drawn"
                        self activeHand position: pt.
                        self world displayWorldSafely.
                        Display fill: colorPatch bounds fillColor: feedbackColor].
        Sensor waitNoButton.
        self activeHand showTemporaryCursor: nil hotSpotOffset: 0 @ 0.
        self currentColor: feedbackColor.
        colorMemory delete.
		 
        tool
                ifNotNil: 
                        [tool state: #on.
                        currentCursor _ tool arguments at: 3].

        aButton state: #off