readFrom: aStream
	| bc year month day hour minute second nanos offset buffer ch |


	aStream peek = $- ifTrue: [ aStream next. bc _ -1] ifFalse: [bc _ 1].
	year _ (aStream upTo: $-) asInteger * bc.
	month _ (aStream upTo: $-) asInteger.
	day _ (aStream upTo: $T) asInteger.
	hour _ (aStream upTo: $:) asInteger.
 	buffer _ '00:' copy. ch _ nil.
	minute _ WriteStream on: buffer.
	[ aStream atEnd | (ch = $:) | (ch = $+) | (ch = $-) ]
		whileFalse: [ ch _ minute nextPut: aStream next. ].
	(ch isNil or: [ch isDigit]) ifTrue: [ ch _ $: ].
	minute _ ((ReadStream on: buffer) upTo: ch) asInteger.
	buffer _ '00.' copy.
	second _ WriteStream on: buffer.
	[ aStream atEnd | (ch = $.) | (ch = $+) | (ch = $-) ]
		whileFalse: [ ch _ second nextPut: aStream next. ].
	(ch isNil or: [ch isDigit]) ifTrue: [ ch _ $. ].
	second _ ((ReadStream on: buffer) upTo: ch) asInteger.
	buffer _ '000000000+' copy.
	(ch = $.) ifTrue: [ 
		nanos _ WriteStream on: buffer.
		[ aStream atEnd | ((ch := aStream next) = $+) | (ch = $-) ]
			whileFalse: [ nanos nextPut: ch. ].
		(ch isNil or: [ch isDigit]) ifTrue: [ ch _ $+ ].
	].

	nanos _ buffer asInteger.
	aStream atEnd
		ifTrue: [ offset _ self localOffset ]
	
	ifFalse:
		 	[offset _ Duration fromString: (ch asString, '0:', aStream upToEnd).
	
		(offset = self localOffset) ifTrue: [ offset _ self localOffset ]].
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
