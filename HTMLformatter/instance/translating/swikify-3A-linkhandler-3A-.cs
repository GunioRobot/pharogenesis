swikify: aStringOrStream linkhandler: aBlock
	| sourceStream aLine targetStream start end forbidden ignore |
	(aStringOrStream isKindOf: Stream)
		ifTrue: [sourceStream := aStringOrStream]
		ifFalse: [sourceStream := ReadStream on: aStringOrStream].
	forbidden _ self rangesOfAngleBrackets: sourceStream.
	targetStream := WriteStream on: String new.
	[sourceStream atEnd] whileFalse:
		[aLine := sourceStream upTo: (Character cr).
		" Now, look for links "
		start _ 1.
		[(start _ aLine indexOfSubCollection: (specialCharacter asString) 
				startingAt: start ifAbsent: [0]) ~= 0
			and: [start < aLine size]]
		whileTrue:
			[(aLine at: start+1) = specialCharacter
			ifTrue: [aLine _ aLine copyReplaceFrom: start to: start+1 
						with: specialCharacter asString.
					start_start + 1. ]
			ifFalse: [
				(end _ aLine indexOfSubCollection: (specialCharacter asString) 
					startingAt: (start+1) ifAbsent: [0]) ~= 0
				ifTrue: [aLine _ aLine copyReplaceFrom: start to: end
						with: (aBlock value: (aLine copyFrom: start+1 to: end-1))]
				ifFalse: [start _ start + 1]]].

		"If it's at least 4 dashes, make it a horizontal rule"
		(aLine indexOfSubCollection: '----' startingAt: 1) = 1
			ifTrue: [targetStream nextPutAll: '<hr>']
			ifFalse: [targetStream nextPutAll: aLine].
		"Should there be a <br> after this line?"
		(ignore _ sourceStream peek = $<) ifTrue: [
			"If just before a tag, ignore the newline"
			targetStream nextPut: $ ].	"but do put in a separator"
		forbidden do: [:interval |
			(interval includes: sourceStream position) ifTrue: [ignore _ true]].
		ignore ifFalse: [
			(sourceStream peek) = (Character cr)
				ifTrue: [sourceStream next. targetStream nextPutAll: '<p>'; cr.]
				ifFalse: [targetStream nextPutAll: '<br>'; cr.]]].
	^targetStream contents.
