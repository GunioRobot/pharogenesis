currentMenuFlap
        "answer the global menu flap or nil."

        ^self globalFlapTabsIfAny detect: [:aTab | 
                (aTab submorphs size > 0) and:  [(aTab submorphs first isKindOf: TextMorph) and: 
                [(aTab submorphs first contents string copyWithout: $ ) = 'Menus']]
        ] ifNone: [nil]
