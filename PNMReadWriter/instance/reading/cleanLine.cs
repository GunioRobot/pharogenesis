cleanLine
	"upTo LF or CR, tab as space"
	| line loop b |
	line := String new writeStream.
	loop := true.
	[ loop ] whileTrue: 
		[ b := stream next.
		b 
			ifNil: [ loop := false	"EOS" ]
			ifNotNil: 
				[ (b = Character cr or: [ b = Character lf ]) 
					ifTrue: [ loop := false ]
					ifFalse: 
						[ b = Character tab ifTrue: [ b := Character space ].
						line nextPut: b ] ] ].
	^ line contents