convertCRtoLF: fileName
	"Convert the given file to LF line endings. Put the result in a file with the extention '.lf'"

	| in out c justPutCR |
	in _ (FileStream oldFileNamed: fileName) binary.
	out _  (FileStream newFileNamed: fileName, '.lf') binary.
	justPutCR _ false.
	[in atEnd] whileFalse: [
		c _ in next.
		c = 10
			ifTrue: [
				out nextPut: 13.
				justPutCR _ true]
			ifFalse: [
				(justPutCR and: [c = 10]) ifFalse: [out nextPut: c].
				justPutCR _ false]].
	in close.
	out close.
