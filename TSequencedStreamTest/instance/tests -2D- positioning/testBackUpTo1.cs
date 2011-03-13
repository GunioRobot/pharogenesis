testBackUpTo1
	|stream|
	stream := ReadStream on: 'abcdabg'.
	stream setToEnd.
	self assert: (stream backUpTo: 'ab').
	self assert: stream peek = $g