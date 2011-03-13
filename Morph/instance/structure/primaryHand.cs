primaryHand

        | outer |
        outer _ self outermostWorldMorph ifNil: [^ nil].
        ^ outer activeHand ifNil: [outer firstHand]