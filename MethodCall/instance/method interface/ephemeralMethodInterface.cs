ephemeralMethodInterface
	"Answer a methodInterface for me. If I have one stored, answer it; if 
	not, conjure up an interface and answer it but do NOT store it 
	internally. You can call this directly if you need a method interface 
	for me but do not want any conjured-up interface to persist."
	^ methodInterface
		ifNil: [MethodInterface new
				conjuredUpFor: selector
				class: (self receiver class whichClassIncludesSelector: selector)]