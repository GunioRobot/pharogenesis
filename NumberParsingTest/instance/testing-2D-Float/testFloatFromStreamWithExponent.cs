testFloatFromStreamWithExponent
	"This covers parsing in Number>>readFrom:"

	| rs aFloat |
	rs _ '1.0e-14' readStream.
	aFloat _ Number readFrom: rs.
	self assert: 1.0e-14 = aFloat.
	self assert: rs atEnd.

	rs _ '1.0e-14 1' readStream.
	aFloat _ Number readFrom: rs.
	self assert: 1.0e-14 = aFloat.
	self assert: rs upToEnd = ' 1'.

	rs _ '1.0e-14eee' readStream.
	aFloat _ Number readFrom: rs.
	self assert: 1.0e-14 = aFloat.
	self assert: rs upToEnd = 'eee'.

	rs _ '1.0e14e10' readStream.
	aFloat _ Number readFrom: rs.
	self assert: 1.0e14 = aFloat.
	self assert: rs upToEnd = 'e10'.

	rs _ '1.0e+14e' readStream. "Plus sign is not parseable"
	aFloat _ Number readFrom: rs.
	self assert: 1.0 = aFloat.
	self assert: rs upToEnd = 'e+14e'.
