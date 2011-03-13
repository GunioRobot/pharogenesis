at: i at: j add: value
    "add value to the element"
    | index |
    (i < 1) | (i > width) ifTrue: [
        ^ self error: 'first index out of bounds'].
    "second index bounds check is automatic, since contents
        array will get a bounds error."

    index _ (j - 1) * width + i.
    ^ contents at: index put: (contents at: index) + value