runTiming
"
DigitalSignatureAlgorithm runTiming
"
	| results ops modeNames |

	modeNames _ #('standard dsa' 'standard integer' 'digitDiv:neg:').
	results _ OrderedCollection new.
	1 to: 3 do: [ :mode |
		results add: (DigitalSignatureAlgorithm timeMultiply: 100000 mode: mode),{mode}.
		results add: (DigitalSignatureAlgorithm timeRemainder: 100000 mode: mode),{mode}.
		results add: (DigitalSignatureAlgorithm timeToDivide: 100000 mode: mode),{mode}.
	].
	ops _ (results collect: [ :each | each second]) asSet asSortedCollection.
	ops do: [ :eachOp |
		results do: [ :eachResult |
			eachResult second = eachOp ifTrue: [
				Transcript show: eachResult first asStringWithCommas,'  ',
					eachResult second ,' took ',
					eachResult third asStringWithCommas,' ms using ',
					(modeNames at: eachResult fourth); cr
			].
		].
		Transcript cr.
	].

