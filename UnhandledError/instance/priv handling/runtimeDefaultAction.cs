runtimeDefaultAction
	"Dump the stack trace to a log file, then exit the program (image)."

	| file |
	file := FileStream newFileNamed: ('error', Utilities dateTimeSuffix, FileDirectory dot, 'log') asFileName.
	SmalltalkImage current timeStamp: file.
	(thisContext sender stackOfSize: 20) do: [:ctx | file cr. ctx printOn: file].
	file close.

	SmalltalkImage current snapshot: false andQuit: true