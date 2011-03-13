hasFulfilledConfiguration
	"Is any of the configurations already fulfilled?
	A fulfilled configuration has all required releases
	already installed, this means the release can be
	trivially installed."
	
	^self workingConfigurations anySatisfy: [:c | c isFulfilled]