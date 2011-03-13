atRow: j put: list
    "Put in a whole row.
     hold second index constant"

    list size = self width ifFalse: [self error: 'wrong size']
    list doWithIndex: [:value :i |
        self at: i at: j put: value].