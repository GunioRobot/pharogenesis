search: element updating: array
        | node forward |
        node := self.
        level to: 1 by: -1 do: [:i |
                        [forward := node forward: i.
                        self is: forward before: element] whileTrue: [node := forward].
                        "At this point: node < element <= forward"
                        array ifNotNil: [array at: i put: node]].
        node := node next.
        ^ (self is: node theNodeFor: element) ifTrue: [node]