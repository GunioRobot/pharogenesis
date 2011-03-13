testBackUpToEmptyPattern1
	"This test represents the current behavior which is not clearly defined and could be revised."
	|stream|
	stream := ReadStream on: 'abcdabg'.
	stream setToEnd.
	self should: [stream backUpTo: ''] raise: Error.