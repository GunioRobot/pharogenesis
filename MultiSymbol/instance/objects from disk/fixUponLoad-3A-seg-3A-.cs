fixUponLoad: aProject seg: anImageSegment
	"We are in an old project that is being loaded from disk.
Fix up conventions that have changed."
	| ms |

	"Yoshiki did not put MultiSymbols into outPointers in older
images!  When all old images are gone, remove this method."
	ms _ MultiSymbol intern: self asString.
	self == ms ifFalse: ["For a project from older m17n image,
this is necessary."
				self becomeForward: ms.
				aProject projectParameters at:
#MultiSymbolInWrongPlace put: true].

	^ super fixUponLoad: aProject seg: anImageSegment	"me,
not the label"
