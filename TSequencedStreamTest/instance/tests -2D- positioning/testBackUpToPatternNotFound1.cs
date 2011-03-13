testBackUpToPatternNotFound1
	|stream|
	stream := ReadStream on: 'abcdabg'.
	stream setToEnd.
	self deny: (stream backUpTo: 'zz').
	self assert: stream position = 0