at: i at: j put: value
    "return the element"
    (i < 1) | (i > width) ifTrue: [
        ^ self error: 'first index out of bounds'].
    "second index bounds check is automatic, since contents
        array will get a bounds error."

    ^ contents at: (j - 1) * width + i put: value