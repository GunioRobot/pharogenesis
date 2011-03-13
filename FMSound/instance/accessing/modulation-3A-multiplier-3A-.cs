modulation: mod multiplier: mult

	| modInRange multInRange |
	modInRange _ mod rounded min: 1023 max: 0.
	multInRange _ mult asFloat max: 0.0.
	initialModulation _ (modInRange * increment) bitShift: -7.
	modulation _ initialModulation.
	offsetIncrement _ (increment * multInRange) rounded.
	offsetIndex _ 1.
