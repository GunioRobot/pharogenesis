next
    | char secondChar |
    char _ super next.
    self isBinary ifTrue: [^char].
    char == Cr ifTrue:
        [secondChar _ super next.
        secondChar ifNotNil: [secondChar == Lf ifFalse: [self skip: -1]].
        ^Cr].
    char == Lf ifTrue: [^Cr].
    ^char