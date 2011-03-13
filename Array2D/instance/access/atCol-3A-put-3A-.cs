atCol: i put: list
    "Put in a whole column.
     hold first index constant"

    list size = self height ifFalse: [self error: 'wrong size']
    list doWithIndex: [:value :j |
        self at: i at: j put: value].