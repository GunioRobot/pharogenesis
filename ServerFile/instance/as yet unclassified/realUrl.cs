realUrl
	"a fully expanded version of the url we represent.  Prefix the path with http: or ftp: or file:"

	self isTypeFile ifTrue: [
		self fileNameRelativeTo: self.
		^ urlObject toText
	].
	^ self typeWithDefault asString, '://', self pathName, '/', fileName	"note difference!"
	