becomeTextuallyCoded
	"Transform the receiver into one which is textually coded"

	isTextuallyCoded _ true.
	lastSourceString _ (playerClass compiledMethodAt: selector) decompileString 		"Save this to compare when going back to tiles"