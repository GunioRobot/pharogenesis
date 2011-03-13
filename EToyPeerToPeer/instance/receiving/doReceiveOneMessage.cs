doReceiveOneMessage

	| awaitingLength i length answer |

	awaitingLength := true.
	answer := WriteStream on: String new.
	[awaitingLength] whileTrue: [
		leftOverData := leftOverData , socket receiveData.
		(i := leftOverData indexOf: $ ) > 0 ifTrue: [
			awaitingLength := false.
			length := (leftOverData first: i - 1) asNumber.
			answer nextPutAll: (leftOverData allButFirst: i).
		].
	].
	leftOverData := ''.
	[answer size < length] whileTrue: [
		answer nextPutAll: socket receiveData.
		communicatorMorph commResult: {#commFlash -> true}.
	].
	answer := answer contents.
	answer size > length ifTrue: [
		leftOverData := answer allButFirst: length.
		answer := answer first: length
	].
	^answer

