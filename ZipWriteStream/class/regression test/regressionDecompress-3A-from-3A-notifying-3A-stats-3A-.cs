regressionDecompress: aFile from: tempFile notifying: progressBar stats: stats
	"Validate aFile as decompressed from tempFile"
	| unzip rawSize compressedSize buffer1 buffer2 |
	rawSize _ aFile size.
	compressedSize _ tempFile size.
	aFile ascii.
	aFile position: 0.
	tempFile ascii.
	tempFile position: 0.
	buffer1 _ String new: 4096.
	buffer2 _ buffer1 copy.
	unzip _ FastInflateStream on: tempFile.
	[aFile atEnd] whileFalse:[
		progressBar value: aFile position.
		buffer1 _ aFile nextInto: buffer1.
		buffer2 _ unzip nextInto: buffer2.
		buffer1 = buffer2
			ifFalse:[^self logProblem: 'contents ' for: aFile].
	].
	unzip next = nil ifFalse:[^self logProblem: 'EOF' for: aFile].
	stats at: #rawSize put:
		(stats at: #rawSize ifAbsent:[0]) + rawSize.
	stats at: #compressedSize put:
		(stats at: #compressedSize ifAbsent:[0]) + compressedSize.
	^compressedSize asFloat / rawSize asFloat.