readFrom: aStream
	"Formatted as per ANSI 5.8.2.16: [-]D:HH:MM:SS[.S]
	To assiste DateAndTime>>#readFrom: SS may be unpadded or absent."

	| sign days hours minutes seconds nanos ws ch |
	sign _ (aStream peekFor: $-) ifTrue: [-1] ifFalse: [1].

	days _ (aStream upTo: $:) asInteger sign: sign.
	hours _ (aStream upTo: $:) asInteger sign: sign.
	minutes _ (aStream upTo: $:) asInteger sign: sign.

	aStream atEnd 
		ifTrue: [seconds _ 0. nanos _ 0]
		ifFalse: 
			[ ws _ String new writeStream.
			[ch _ aStream next. (ch isNil) | (ch = $.)]
				whileFalse: [ ws nextPut: ch ].
			seconds _ ws contents asInteger sign: sign.
			ws reset.
			9 timesRepeat: 
				[ ch _ aStream next. 
				ws nextPut: (ch ifNil: [$0] ifNotNil: [ch]) ].
			nanos _ ws contents asInteger sign: sign].

	^ self days: days hours: hours minutes: minutes seconds: seconds nanoSeconds: nanos.

	"	'0:00:00:00' asDuration
		'0:00:00:00.000000001' asDuration
		'0:00:00:00.999999999' asDuration
		'0:00:00:00.100000000' asDuration
		'0:00:00:00.10' asDuration
		'0:00:00:00.1' asDuration
		'0:00:00:01' asDuration
		'0:12:45:45' asDuration
		'1:00:00:00' asDuration
		'365:00:00:00' asDuration
		'-7:09:12:06.10' asDuration
		'+0:01:02' asDuration
		'+0:01:02:3' asDuration
 	"
