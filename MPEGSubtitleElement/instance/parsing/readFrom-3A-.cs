readFrom: aStream 
	"Private - Read the receiver's contents from aStream."
	self mustBe: '{' in: aStream.
	initialFrame := self nextIntegerFrom: aStream.
	self mustBe: '}{' in: aStream.
	endFrame := self nextIntegerFrom: aStream.
	self mustBe: '}' in: aStream.
	""
	self contents: aStream nextLine isoToSqueak