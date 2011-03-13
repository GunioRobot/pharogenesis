at: element ifAbsent: aBlock
        "Get the key if it exists, or if it doesn't exist, get the key just after it."
        | node forward |
        node _ self.
        level to: 1 by: -1 do: [:i |
                        [forward _ node forward: i.
                        self is: forward before: element] whileTrue: [node _ forward]].
        node _ node next.
        (self is: node theNodeFor: element) ifFalse: [^aBlock value].
        ^node value
