makeForegroundColor
        "Make a foreground color contrasting with me"
        ^self luminance >= "Color red luminance" 0.299
                ifTrue: [Color black]
                ifFalse: [Color white]