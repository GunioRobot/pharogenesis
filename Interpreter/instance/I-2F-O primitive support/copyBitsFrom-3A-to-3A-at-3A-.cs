copyBitsFrom: x0 to: x1 at: y
	"This entry point needs to be implemented for the interpreter proxy.
	Since BitBlt is now a plugin we need to look up BitBltPlugin_copyBitsFrom:to:at:
	and call it. This entire mechanism should eventually go away and be
	replaced with a dynamic lookup from BitBltPlugin itself but for backward
	compatibility this stub is provided"
	| fn |
	fn _ self ioLoadFunction: 'copyBitsFromtoat' From: 'BitBltPlugin'.
	fn = 0 ifTrue:[^self primitiveFail].
	^self cCode:' ((int (*) (int, int, int)) fn)(x0, x1, y)'