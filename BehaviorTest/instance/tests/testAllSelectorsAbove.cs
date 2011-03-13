testAllSelectorsAbove
	"self debug: #testAllSelectorsAbove"
	
	|sels |
	sels := Morph allSelectorsAbove.
	self deny: (sels includes: #submorphs). 
	self deny: (sels includes: #submorphs).
	self assert: (sels includes: #clearHaltOnce).
	self assert: (sels includes: #cannotInterpret: )
	