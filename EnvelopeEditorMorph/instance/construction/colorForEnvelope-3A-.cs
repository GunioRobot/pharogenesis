colorForEnvelope: env
	| name index |
	name _ env name.
	index _ #('volume' 'modulation' 'pitch' 'ratio') indexOf: name
				ifAbsent: [5].
	^ Color perform: (#(red green blue magenta black) at: index)