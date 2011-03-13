forceNewFrom: anArray
    "Create a new instance of the class and fill
    its instance variables up with the array."
    | object max |

    object _ self new.
    max _ self instSize.
    anArray doWithIndex: [:each :index |
        index > max ifFalse:
            [object instVarAt: index put: each]].
    ^ object