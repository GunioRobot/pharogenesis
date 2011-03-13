search: element 
        "Get the key if it exists, or if it doesn't exist, get the key just after it. If no key after it, return nil."
        | node forward |
        node := self.
        level to: 1 by: -1 do: [:i |
                        [forward := node forward: i.
                        self is: forward before: element] whileTrue: [node := forward]].
        node := node next.
        ^node