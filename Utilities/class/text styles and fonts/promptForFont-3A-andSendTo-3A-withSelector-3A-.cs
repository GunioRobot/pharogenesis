promptForFont: aPrompt andSendTo: aTarget withSelector: aSelector
        "Utilities promptForFont: 'Choose system font:' andSendTo: Utilities withSelector: #setSystemFontTo:"
        "NOTE: Morphic ONLY!!.  Derived from a method written by Robin Gibson"

        | menu subMenu |
        menu _ MenuMorph entitled: aPrompt.
        Utilities actualTextStyles keys do: [:styleName|
                subMenu _ self fontMenuForStyle: styleName target: aTarget selector: aSelector.
                menu add: styleName subMenu: subMenu.
                menu lastItem font: ((TextStyle named: styleName) fontOfSize: 18)].

        menu popUpForHand: self currentHand