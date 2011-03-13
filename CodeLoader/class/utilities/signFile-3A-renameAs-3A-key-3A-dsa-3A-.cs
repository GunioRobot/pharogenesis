signFile: fileName renameAs: destFile key: privateKey dsa: dsa
	"Sign the given file using the private key."
	| in hash sig out |
	in _ FileStream readOnlyFileNamed: fileName.
	in binary.
	hash _ SecureHashAlgorithm new hashStream: in.
	sig _ dsa computeSignatureForMessageHash: hash privateKey: privateKey.
	out _ FileStream newFileNamed: destFile.
	out binary.
	out nextPutAll: sig first; nextPutAll: sig last.
	in position: 0.
	[in atEnd] whileFalse:[out nextPutAll: (in next: 4096)].
	in close.
	out close.