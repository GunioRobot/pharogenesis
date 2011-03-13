remove: key ifAbsent: aBlock
        | node i s |
        "Remove and return th association containing key."
        node := self search: key updating: splice.
        node ifNil: [^ aBlock value].
        i := 1.
        [s := splice at: i.
        i <= level and: [(s forward: i) == node]]
                                whileTrue:
                                        [s atForward: i put: (node forward: i).
                                        i := i + 1].
        numElements := numElements - 1.
        splice atAllPut: nil.
        ^ node.
