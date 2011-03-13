search: element updating: array
        | node forward |
        node _ self.
        level to: 1 by: -1 do: [:i |
                        [forward _ node forward: i.
                        self is: forward before: element] whileTrue: [node _ forward].
                        "At this point: node < element <= forward"
                        array ifNotNil: [array at: i put: node]].
        node _ node next.
        ^ (self is: node theNodeFor: element) ifTrue: [node]