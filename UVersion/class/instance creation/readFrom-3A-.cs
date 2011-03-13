readFrom: stream
	| components |
	components _ OrderedCollection new.
	[ stream atEnd ] whileFalse: [
		stream peek isDigit ifTrue: [
			components add: (Integer readFrom: stream) ]
		ifFalse: [
			components add: (String streamContents: [ :compStr |
				[ stream atEnd not and: [ stream peek isDigit not ] ] whileTrue: [
					compStr nextPut: stream next ] ]) ] ].
		
	^self fromComponents: components