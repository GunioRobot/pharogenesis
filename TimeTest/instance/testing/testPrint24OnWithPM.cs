testPrint24OnWithPM
	| cs rw |
	cs := ReadStream on: '12:34:56 pm'.
	rw := ReadWriteStream on: ''.
	aTime print24: false on: rw.
	^ self assert: rw contents = cs contents