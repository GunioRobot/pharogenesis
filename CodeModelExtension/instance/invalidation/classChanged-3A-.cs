classChanged: modificationEvent 
	"We dont want to provide an out of date reply"
	modificationEvent itemClass ifNil: [self].
	self clearOut: modificationEvent itemClass
