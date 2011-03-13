updateMenuFlap
        | aFlap selectors newMenu newMenuTitle oldMenu |

        aFlap _ (self currentMenuFlap ifNil: [^self]) referent.
        selectors _ #(openMenu helpMenu windowsMenu changesMenu 
                debugMenu playfieldMenu scriptingMenu ).
        selectors do: [:menuSelector |
                (newMenu _ self currentWorld getWorldMenu: menuSelector)
                        beSticky;
                        stayUp: true.
                newMenu submorphs second delete.        "remove the stay up item"
                newMenu borderWidth: 1.

                (newMenuTitle _ newMenu titleGuesstimate) ifNotNil: [
                        oldMenu _ aFlap 
                                findDeepSubmorphThat: [ :each |
                                        (each isKindOf: MenuMorph) and: 
                                                [each titleGuesstimate = newMenuTitle]
                                ] 
                                ifAbsent: [nil].
                        oldMenu ifNotNil: [
                                oldMenu owner
                                        replaceSubmorph: oldMenu 
                                        by: newMenu.
                        ].
                ].
        ].
        ^ aFlap