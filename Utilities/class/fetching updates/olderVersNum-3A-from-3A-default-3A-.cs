olderVersNum: restOfText from: updateStrm default: sequence
	| savePos before rest after |
	"Inserting an update in an earlier version, not the latest.  See if there is a gap in the numbering, and pick the lowest unused number there."

"number before"
savePos _ updateStrm position.   before _ after _ nil.
[before == nil] whileTrue: [
	[(updateStrm next = Character cr)] whileFalse: [updateStrm skip: -2].
	updateStrm peek isDigit 
		ifTrue: [before _ SmallInteger readFrom: updateStrm]
		ifFalse: [updateStrm skip: -4]].
updateStrm position: savePos.

"number after"
rest _ ReadStream on: restOfText.
[after == nil & (rest atEnd not)] whileTrue: [
	[(rest next = Character cr)] whileFalse.
	rest peek isDigit 
		ifTrue: [after _ SmallInteger readFrom: rest]].
after ifNil: [^ sequence].

"is there a gap?"
^ after - before > 1 ifTrue: [before] ifFalse: [sequence]