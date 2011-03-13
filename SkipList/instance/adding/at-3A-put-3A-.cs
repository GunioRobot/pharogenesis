at: key put: value 
        "Add an association or key on to the skiplist"
        ^self at: key put: value ifPresent: [].
        