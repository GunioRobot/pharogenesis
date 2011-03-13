readFrom: aStream
	| bc year month day hour minute second nanos offset buffer ch |


	aStream peek = $- ifTrue: [ aStream next. bc := -1] ifFalse: [bc := 1].
	year := (aStream upTo: $-) asInteger * bc.
	month := (aStream upTo: $-) asInteger ifNil: [1].
	day := (aStream upTo: $T) asInteger ifNil: [1].
	hour := (aStream upTo: $:) asInteger ifNil: [0].
 	buffer := '00:' copy. ch := nil.
	minute := buffer writeStream.
	[ aStream atEnd | (ch = $:) | (ch = $+) | (ch = $-) ]
		whileFalse: [ ch := minute nextPut: aStream next. ].
	(ch isNil or: [ch isDigit]) ifTrue: [ ch := $: ].
	minute := (buffer readStream upTo: ch) asInteger.
	buffer := '00.' copy.
	second := buffer writeStream.
	[ aStream atEnd | (ch = $.) | (ch = $+) | (ch = $-) ]
		whileFalse: [ ch := second nextPut: aStream next. ].
	(ch isNil or: [ch isDigit]) ifTrue: [ ch := $. ].
	second := (buffer readStream upTo: ch) asInteger.
	buffer := '000000000' copy.
	(ch = $.) ifTrue: [ 
		nanos := buffer writeStream.
		[ aStream atEnd | ((ch := aStream next) = $+) | (ch = $-) ]
			whileFalse: [ nanos nextPut: ch. ].
		(ch isNil or: [ch isDigit]) ifTrue: [ ch := $+ ].
	].

	nanos := buffer asInteger.
	aStream atEnd
		ifTrue: [ offset := self localOffset ]
	
	ifFalse:
		 	[offset := Duration fromString: (ch asString, '0:', aStream upToEnd).
	
		(offset = self localOffset) ifTrue: [ offset := self localOffset ]].
	^ self
		year: year
		month: month
		day: day
		hour: hour
		minute: minute

		second: second
		nanoSecond:  nanos

		offset: offset.


	"	'-1199-01-05T20:33:14.321-05:00' asDateAndTime
		' 2002-05-16T17:20:45.1+01:01' asDateAndTime

		' 2002-05-16T17:20:45.02+01:01' asDateAndTime

		' 2002-05-16T17:20:45.003+01:01' asDateAndTime

		' 2002-05-16T17:20:45.0004+01:01' asDateAndTime
  		' 2002-05-16T17:20:45.00005' asDateAndTime
		' 2002-05-16T17:20:45.000006+01:01' asDateAndTime

		' 2002-05-16T17:20:45.0000007+01:01' asDateAndTime
		' 2002-05-16T17:20:45.00000008-01:01' asDateAndTime   
		' 2002-05-16T17:20:45.000000009+01:01' asDateAndTime  
		' 2002-05-16T17:20:45.0000000001+01:01' asDateAndTime  

 		' 2002-05-16T17:20' asDateAndTime
		' 2002-05-16T17:20:45' asDateAndTime
		' 2002-05-16T17:20:45+01:57' asDateAndTime
 		' 2002-05-16T17:20:45-02:34' asDateAndTime
 		' 2002-05-16T17:20:45+00:00' asDateAndTime
		' 1997-04-26T01:02:03+01:02:3' asDateAndTime 
 	"
