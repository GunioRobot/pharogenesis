realUrl
	"a fully expanded version of the url we represent.  Prefix the path with http: or ftp: or file:"

	type = #file ifTrue: [self fileNameRelativeTo: self.
				^ urlObject toText].
	^ type asString, '://', self pathName, '/', fileName	"note difference!"
	