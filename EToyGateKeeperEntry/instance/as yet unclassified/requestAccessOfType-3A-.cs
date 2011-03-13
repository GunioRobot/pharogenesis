requestAccessOfType: aString

	| ok |

	accessAttempts _ accessAttempts + 1.
	lastRequests addFirst: {Time totalSeconds. aString}.
	lastRequests size > 10 ifTrue: [
		lastRequests _ lastRequests copyFrom: 1 to: 10.
	].
	ok _ (acceptableTypes includes: aString) or: [acceptableTypes includes: 'all'].
	ok ifFalse: [attempsDenied _ attempsDenied + 1].
	^ok