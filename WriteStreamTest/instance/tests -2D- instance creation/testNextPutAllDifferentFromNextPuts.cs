testNextPutAllDifferentFromNextPuts
	"self debug: #testNextPutAllDifferentFromNextPuts"
	
	"When a stream is created on a collection, it tries to keep using that collection instead of copying. See thread with title 'Very strange bug on Streams and probably compiler' (Feb 14 2007) on the squeak-dev mailing list."
	
	"nextPutAll verifies the size of the parameter and directly grows the underlying collection of the required size."
	|string stream|
	
	string := String withAll: 'z'.
	stream := WriteStream on: string.
	stream nextPutAll: 'abc'.
	self assert: string = 'z'. "string hasn't been modified because #nextPutAll: detects that 'abc' is bigger than the underlying collection. Thus, it starts by creating a new collection and doesn't modify our variable."
	
	string := String withAll: 'z'.
	stream := WriteStream on: string.
	stream nextPut: $a; nextPut: $b; nextPut: $c.
	self assert: string = 'a'. "The first #nextPut: has no problem and replaces $z by $a in the string. Others will detect that string is too small."