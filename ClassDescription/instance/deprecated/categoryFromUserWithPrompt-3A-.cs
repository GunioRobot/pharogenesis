categoryFromUserWithPrompt: aPrompt
	"SystemDictionary categoryFromUserWithPrompt: 'testing'"

	self deprecated: 'Use CodeHolder>>categoryFromUserWithPrompt: aPrompt for: aClass instead'.
	"this deprecation helps to remove UI dependency from the core of Squeak.
	Normally only CodeHolder was calling this method"
	CodeHolder new categoryFromUserWithPrompt: aPrompt for: self