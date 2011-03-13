installFileNamed: filename
	| stream baseName |
	stream _ (FileStream readOnlyFileNamed: filename).
	baseName _ (FileDirectory splitName: filename to: [:path :base|base]) copyUpTo: $. .

	self install: stream usingBaseName: baseName.
	stream close.
	