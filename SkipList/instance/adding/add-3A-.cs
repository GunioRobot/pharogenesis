add: element 
        "Add an association or key on to the skiplist"
        ^self add: element ifPresent: [].
        