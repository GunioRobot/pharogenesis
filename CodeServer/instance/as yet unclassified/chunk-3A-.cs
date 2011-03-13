chunk: request
	"Return Smalltalk source code as a chunk from the changes file.  
URL = machine:80/chunk.Point|min;  included are:  Point|at;   Point|Comment   Point|Hierarchy  Point|Definition   Point|class|x;y;
	Meant to be received by a Squeak client, not a browser.  Reply not in HTML"

	| classAndMethod set strm chunk |
	classAndMethod _ request message atPin: 2.
	classAndMethod _ classAndMethod copyReplaceAll: '|' with: ' '.
	classAndMethod _ classAndMethod copyReplaceAll: ';' with: ':'.
	set _ LinkedMessageSet messageList: (Array with: classAndMethod).
	strm _ WriteStream on: (String new: 300).
	strm nextChunkPutWithStyle: (set selectedMessage). "String or text"
	chunk _ strm contents.

	request reply: 'content-length: ', chunk size printString, PWS crlfcrlf.
	request reply: chunk.
