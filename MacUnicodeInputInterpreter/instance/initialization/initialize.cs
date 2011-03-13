initialize
	| satisfiesVersion |
	satisfiesVersion := self
				majorMinorBuildFrom: SmalltalkImage current vmVersion
				satisfies: [:major :minor :build | major >= 3
						and: [minor >= 8
								and: [build >= 7]]].
	satisfiesVersion
		ifTrue: [keyValueIndex := 6]
		ifFalse: [keyValueIndex := 3]