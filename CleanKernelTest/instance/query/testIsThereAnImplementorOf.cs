testIsThereAnImplementorOf
	"self run: #testIsThereAnImplementorOf"

	self deny: (SystemNavigation new isThereAnImplementorOf: #nobodyImplementsThis) .
	self assert: (SystemNavigation new isThereAnImplementorOf: #zoulouSymbol).