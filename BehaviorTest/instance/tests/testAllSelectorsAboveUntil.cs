testAllSelectorsAboveUntil
	"self debug: #testAllSelectorsAboveUntil"
	
	|sels |
	sels := Morph allSelectorsAboveUntil: Object..
	self deny: (sels includes: #submorphs). 
	self deny: (sels includes: #submorphs).
	self assert: (sels includes: #clearHaltOnce).
	self deny: (sels includes: #cannotInterpret: )
	