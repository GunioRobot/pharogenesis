testIntegerReadFrom
	"Ensure remaining characters in a stream are not lost when parsing an integer."

	| rs i s |
	rs _ ReadStream on: '123s could be confused with a ScaledDecimal'.
	i _ Number readFrom: rs.
	self assert: i == 123.
	s _ rs upToEnd.
	self assert: 's could be confused with a ScaledDecimal' = s.
	rs _ ReadStream on: '123.s could be confused with a ScaledDecimal'.
	i _ Number readFrom: rs.
	self assert: i == 123.
	s _ rs upToEnd.
	self assert: '.s could be confused with a ScaledDecimal' = s.
	rs _ ReadStream on: '123sA has unary message sA'.
	i _ Number readFrom: rs.
	self assert: i == 123.
	s _ rs upToEnd.
	self assert: 'sA has unary message sA' = s.	
	rs _ ReadStream on: '123sB has unary message sB'.
	i _ Number readFrom: rs.
	self assert: i == 123.
	s _ rs upToEnd.
	self assert: 'sB has unary message sB' = s.
