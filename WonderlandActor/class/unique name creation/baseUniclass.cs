baseUniclass
	"Answer the uniclass that new instances should be instances of; this protocol allows for individual cards of a background to have their own class"

	| curr |
	curr _ self.
	[curr theNonMetaClass superclass name endsWithDigit]
		whileTrue:
			[curr _ curr superclass].
	^ curr

"CardPlayer100 baseUniclass 
CardPlayer100X baseUniclass
"