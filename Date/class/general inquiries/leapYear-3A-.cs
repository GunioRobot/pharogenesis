leapYear: yearInteger
 "Answer 1 if the year yearInteger is a leap year; answer 0 if it is not."

    | adjustedYear |
    adjustedYear := yearInteger > 0
        ifTrue: [yearInteger]
        ifFalse: [(yearInteger + 1) negated "There is no year 0!!"].
     (adjustedYear \\ 4 ~= 0 or: [adjustedYear \\ 100 = 0 and: [adjustedYear \\ 400 ~= 0]])
        ifTrue: [^0]
        ifFalse: [^1]