logErrorDuring: block

(IsSetToTrapErrors == false) ifTrue: [ ^ block value ].

block on: Error do: [ :e | self logCR: e messageText. ]