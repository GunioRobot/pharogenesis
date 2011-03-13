remove: key ifAbsent: aBlock
        | node i s |
        "Remove and return th association containing key."
        node _ self search: key updating: splice.
        node ifNil: [^ aBlock value].
        i _ 1.
        [s _ splice at: i.
        i <= level and: [(s forward: i) == node]]
                                whileTrue:
                                        [s atForward: i put: (node forward: i).
                                        i _ i + 1].
        numElements _ numElements - 1.
        splice atAllPut: nil.
        ^ node.
