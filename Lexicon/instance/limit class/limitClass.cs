limitClass
	"Answer the most generic class to show in the browser.  By default, we go all the way up to ProtoObject"

	^ limitClass ifNil: [self initialLimitClass]