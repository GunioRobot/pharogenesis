xDoubleQuote
    "Collect a comment."
    "wod 1/10/98: Allow 'empty' comments by testing the first character
for $"" rather than blindly adding it to the comment being collected."
    | aStream stopChar |
    stopChar _ 30 asCharacter.
    aStream _ WriteStream on: (String new: 200).
    self step.
    [hereChar == $"]
        whileFalse:
            [(hereChar == stopChar and: [source atEnd])
                ifTrue: [^self offEnd: 'Unmatched comment quote'].
            aStream nextPut: self step.].
    self step.
    currentComment == nil
        ifTrue: [currentComment _ OrderedCollection with: aStream
contents]
        ifFalse: [currentComment add: aStream contents].
    self scanToken