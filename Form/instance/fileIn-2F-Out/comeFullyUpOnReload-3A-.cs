comeFullyUpOnReload: smartRefStream
	bits isForm ifFalse:[^self].
	"make sure the resource gets loaded afterwards"
	ResourceCollector current ifNil:[^self].
	ResourceCollector current noteResource: bits replacing: self.
