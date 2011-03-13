testInjectIntoDecompiledDebugs
	"Test various debugs of the decompiled form debug correctly."
	"self new testInjectIntoDecompiledDebugs"
	| source |
	source := (Collection sourceCodeAt: #inject:into:) asString.
	{ Encoder.
	   EncoderForV3PlusClosures. EncoderForLongFormV3PlusClosures } do:
		[:encoderClass| | method |
		method := (Parser new
							encoderClass: encoderClass;
							parse: source
							class: Collection)
						generate: #(0 0 0 0).
		self supportTestSourceRangeAccessForDecompiledInjectInto: method source: method decompileString]