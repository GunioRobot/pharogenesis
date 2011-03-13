oldFileOrNoneNamed: fullName
	"If the file exists, answer a read-only RemoteFileStream on it. If it doesn't, answer nil.  fullName is directory path, and does include name of the server.  Or just a simple fileName.  Do prefetch the data."

	| file |

	Cursor wait showWhile: [
		file _ self asServerFileNamed: fullName.
		file readOnly.
		file isTypeFile ifTrue: [
			^ FileStream oldFileOrNoneNamed: (file fileNameRelativeTo: self)].
		"file exists ifFalse: [^ nil]."		"on the server"

		^self streamOnBeginningOf: file
	].
