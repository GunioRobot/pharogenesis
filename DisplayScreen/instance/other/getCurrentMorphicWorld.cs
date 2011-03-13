getCurrentMorphicWorld

        ^RequestCurrentWorldNotification signal ifNil: [
                (self morphicWorldAt: Sensor cursorPoint) ifNil: [
                        self getOuterMorphicWorld
                ].
        ]

