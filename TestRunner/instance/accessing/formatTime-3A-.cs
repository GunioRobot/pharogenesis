formatTime: aTime
        aTime hours > 0 ifTrue: [^aTime hours printString , 'h'].
        aTime minutes > 0 ifTrue: [^aTime minutes printString , 'min'].
        ^aTime seconds printString , ' sec'