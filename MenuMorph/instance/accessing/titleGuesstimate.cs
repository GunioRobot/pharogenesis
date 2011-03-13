titleGuesstimate

        submorphs isEmpty ifTrue: [^nil].
        (submorphs first isKindOf: AlignmentMorph) ifFalse: [^nil].
        submorphs first submorphsDo: [ :each |
                (each isKindOf: StringMorph) ifTrue: [^each contents]
        ].
        ^nil
