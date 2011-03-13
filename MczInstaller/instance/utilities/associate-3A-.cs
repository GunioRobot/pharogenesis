associate: tokens
	| result |
	result _ Dictionary new.
	tokens pairsDo: [:key :value | 
					value isString ifFalse: [value _ value collect: [:ea | self associate: ea]].
					value = 'nil' ifTrue: [value _ ''].
					result at: key put: value].
	^ result