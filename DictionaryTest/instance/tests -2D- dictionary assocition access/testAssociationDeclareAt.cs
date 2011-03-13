testAssociationDeclareAt

| collection keyIn result |
collection := self nonEmpty.
keyIn := collection keys anyOne.

result := collection associationDeclareAt: keyIn .
self assert: (result key) = keyIn.
self assert: (result value ) = (collection at: keyIn ).

result := collection associationDeclareAt: self keyNotIn  .
self shouldnt: [collection at: self keyNotIn ] raise: Error.
self assert: (collection at: self keyNotIn ) = false.