search: element 
        "Get the key if it exists, or if it doesn't exist, get the key just after it. If no key after it, return nil."
        | node forward |
        node _ self.
        level to: 1 by: -1 do: [:i |
                        [forward _ node forward: i.
                        self is: forward before: element] whileTrue: [node _ forward]].
        node _ node next.
        ^node