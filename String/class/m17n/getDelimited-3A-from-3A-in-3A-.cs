getDelimited: var from: from in: string

	| start end index |

	index _ string findString: var startingAt: from.
	index > 0 ifTrue: [
		start _ index.
		[start > 0 and: [(string at: start) isAlphaNumeric]] whileTrue: [start _ start - 1].
		start _ start + 1.

		end _ index.
		[end <= string size and: [(string at: end) isAlphaNumeric]] whileTrue: [end _ end + 1].
		end _ end - 1.
		((string copyFrom: start to: end) = var) ifTrue: [^ start] ifFalse: [
			^ self getDelimited: var from: index + var size in: string.
		].
	].
	^ 0.
