doReceiveOneMessage

	| awaitingLength i length answer |

	awaitingLength _ true.
	answer _ WriteStream on: String new.
	[awaitingLength] whileTrue: [
		leftOverData _ leftOverData , socket receiveData.
		(i _ leftOverData indexOf: $ ) > 0 ifTrue: [
			awaitingLength _ false.
			length _ (leftOverData first: i - 1) asNumber.
			answer nextPutAll: (leftOverData allButFirst: i).
		].
	].
	leftOverData _ ''.
	[answer size < length] whileTrue: [
		answer nextPutAll: socket receiveData.
		communicatorMorph commResult: {#commFlash -> true}.
	].
	answer _ answer contents.
	answer size > length ifTrue: [
		leftOverData _ answer allButFirst: length.
		answer _ answer first: length
	].
	^answer

