cCodeForSoundPrimitives
	"Return a string containing the C code for the sound primitives. This string is pasted into a file, compiled, and linked into the virtual machine. Note that the virtual machine's primitive table must also be edited to make new primitives available."
	"AbstractSound cCodeForSoundPrimitives"

	^ CCodeGenerator new codeStringForPrimitives: #(
		(FMSound mixSampleCount:into:startingAt:leftVol:rightVol:)
		(PluckedSound mixSampleCount:into:startingAt:leftVol:rightVol:)
		(SampledSound mixSampleCount:into:startingAt:leftVol:rightVol:)
		(ReverbSound applyReverbTo:startingAt:count:)
	).
