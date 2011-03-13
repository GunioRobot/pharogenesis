readCharactersInRanges: ranges storeInto: chars 
	| array form code rangeStream currentRange |
	rangeStream := ranges readStream.
	currentRange := rangeStream next.
	[ true ] whileTrue: 
		[ array := self readOneCharacter.
		array second ifNil: [ ^ self ].
		code := array at: 2.
		code > currentRange last ifTrue: 
			[ 
			[ rangeStream atEnd not and: 
				[ currentRange := rangeStream next.
				currentRange last < code ] ] whileTrue.
			rangeStream atEnd ifTrue: [ ^ self ] ].
		(code 
			between: currentRange first
			and: currentRange last) ifTrue: 
			[ form := array at: 1.
			form ifNotNil: [ chars add: array ] ] ]