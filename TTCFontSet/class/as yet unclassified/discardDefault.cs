discardDefault
"
	self discardDefault
"
	| ttc |
	ttc _ TTCFontDescription default.
	ttc ifNotNil: [
		TextConstants removeKey: ttc name asSymbol ifAbsent: [].
	].