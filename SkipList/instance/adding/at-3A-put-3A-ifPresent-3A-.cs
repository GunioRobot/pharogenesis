at: key put: value ifPresent: aBlock
        | node lvl s |
        node := self search: key updating: splice.
        node ifNotNil: [^ aBlock value].
        lvl := self randomLevel.
        node := SkipListNode key: key value: value level: lvl.
        level + 1 to: lvl do: [:i | splice at: i put: self].
        1 to: lvl do: [:i |
                                s := splice at: i.
                                node atForward: i put: (s forward: i).
                                s atForward: i put: node].
        numElements := numElements + 1.
        splice atAllPut: nil.
        ^ node
