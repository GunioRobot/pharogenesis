replaceMenuFlap
        "if there is a global menu flap, replace it with an updated one."

        | aFlapTab |
        aFlapTab _ self currentMenuFlap ifNil: [^ self].
        self removeFlapTab: aFlapTab keepInList: false.
        self addGlobalFlap: self menuFlap.
        Smalltalk isMorphic ifTrue: [Display bestGuessOfCurrentWorld addGlobalFlaps]

"Utilities replaceMenuFlap"