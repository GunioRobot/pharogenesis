isCompiledMethod: oop
    "Answer whether the receiver is of compiled method format"
    ^(self formatOf: oop) >= 12
