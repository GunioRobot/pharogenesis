selectorsToBeIgnored

	 | deprecated private special primitives timing benchmarks |

	deprecated := #().
	private := #( #hours: #hours:minutes:seconds: #setSeconds: #print24:on: #print24:showSeconds:on: ).
	special := #( #< #= #new #printOn: #storeOn: ).
	primitives := #( #primMillisecondClock #primSecondsClock ).
	timing := #( #millisecondClockValue #milliseconds:since: #millisecondsSince: ).
	benchmarks := #( #benchmarkMillisecondClock #benchmarkPrimitiveResponseDelay ). 

	^ super selectorsToBeIgnored, deprecated, private, special, primitives, timing, benchmarks.