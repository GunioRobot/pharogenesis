methodHeader: obj
	"Return the integer encoding the attributes of this method"
	"See the comment in CompiledMethod newBytes:nArgs:nTemps:nStack:nLits:primitive:"
	^ obj header  "just use what's there"