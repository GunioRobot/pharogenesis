addFlag: flagVal 
	"add flagVal to the flags"
	flags ifNil: [ flags := 0 ].
	flags := flags bitOr: flagVal